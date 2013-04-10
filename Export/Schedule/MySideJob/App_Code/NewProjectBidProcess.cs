using System;
using System.Collections.Generic;
using System.Linq;
using SidejobModel;

/// <summary>
/// Summary description for NewProjectBidProcess
/// Process the new bid and the new opportunity
/// after both the poster and the bidder had 
/// selected that they want to extend the project
/// </summary>
/// 

public class NewProjectBidProcess
{
	public NewProjectBidProcess(int newprod, int projectid)
	{
	    NewProID = newprod;
	    ProjectID = projectid;
	   
	}
    public void StartProcess()
    {
         Process();
    }

    public int NewProID { get; set; }
    public int ProjectID { get; set; }

    private void Process()
    {
        using (var context = new SidejobEntities())
        {

                var newopportunity = (from cp in context.ProjectSecondChances
                                      where  cp.ProjectID == ProjectID
                                      select cp);
                if (newopportunity.Count() == 2)
                {

                    //Save to ArchivedProjectSecondChance
                    SavedToArchivedProjectSecondChance(context, newopportunity);

                    //Delete Previous BidderWin and Bids
                    DeletePreviousBidderWin(context, ProjectID);

                    //Add Current BidderWin
                    AddNewBidderWin(context, ProjectID);

                    //update project 
                    Updateproject(context);

                    //delete from Response Delay
                    DeleteFromResponseDelay(context);
                }
            context.DeleteObject(newopportunity.FirstOrDefault());
            context.SaveChanges();
        }
       
    }

    private void SavedToArchivedProjectSecondChance(SidejobEntities context, IEnumerable<ProjectSecondChance> newopportunity)
    {
        //Saved to ArchivedProjectSecondChance
        foreach (ProjectSecondChance o in newopportunity)
        {
            var p1 = new ArchivedProjectSecondChance
            {
                AgreerID = o.AgreerID,
                AgreerRole = o.AgreerRole,
                AgreerProjectRole = o.AgreerProjectRole,
                ProjectID = o.ProjectID,
                DateTime = DateTime.Now.Date
            };
            if (!string.IsNullOrEmpty(o.AgreerProjectRole = "New Bidder"))
            {
                NewProID = o.AgreerID;
            }
            context.AddToArchivedProjectSecondChances(p1);
           
        } 
        context.SaveChanges();
    }

    private void Updateproject(SidejobEntities context)
    {
        //Delete From ClosedProject
        var closedproject = (from c in context.ClosedProjects
                             where c.ProjectID == ProjectID
                             select c).FirstOrDefault();
        if (closedproject != null)
        {
            context.DeleteObject(closedproject);
        }

        //Update Project Requirement End Date to Today
        var projectrequirement = (from c in context.ProjectsRequirementsMains
                                  where c.ProjectID == ProjectID
                                  select c).FirstOrDefault();
        if (projectrequirement != null)
        {
            projectrequirement.DateFinished = DateTime.Now.Date;
            projectrequirement.AmountOffered = (decimal)GetCurrentNewBid(ProjectID, NewProID).AmountOffered;
            context.SaveChanges();
        }

        //Update HighestBid and BidderID 
        var project = (from c in context.Projects
                       where c.ProjectID == ProjectID
                       select c).FirstOrDefault();
        if (project != null)
        {
            project.HighestBid = GetCurrentNewBid(ProjectID, NewProID).AmountOffered;
            project.HighestBidderID = NewProID;
            project.HighestBidUsername = GetProfessional().UserName;
            project.StatusInt = 0;
            context.SaveChanges();
        }
    }

    public void DeletePreviousBidderWin(SidejobEntities context, int projectId)
    {
        var previous = (from c in context.ClosedProjects
                        where c.ProjectID == projectId
                        select c.BidderID).FirstOrDefault();

        if (previous != null)
        {
            var bids = (from c in context.Bids
                        where c.ProjectID == projectId && c.BidderID == previous
                        orderby c.AmountOffered descending
                        select c).FirstOrDefault();


            if (bids != null)
            {
                int previousbidid = bids.BidID; 
                context.DeleteObject(bids);
                var previouswinnerbid = (from c in context.ProfessionalWinBids
                                        where c.ProID == previous
                                        && c.BidID == previousbidid
                                        select c).FirstOrDefault();;
                if (previouswinnerbid != null)
                {
                     context.DeleteObject(previouswinnerbid);
                }
               
            }

            context.SaveChanges();
        }
    }

    public  void DeletePreviousBidderWinFromNewOptionSelection(SidejobEntities context, int projectId, int bidderid)
    {
            var bids = (from c in context.Bids
                        where c.ProjectID == projectId && c.BidderID == bidderid
                        orderby c.AmountOffered descending
                        select c).FirstOrDefault();
          if (bids != null)
            {
                int previousbidid = bids.BidID; 
                context.DeleteObject(bids);
                var previouswinnerbid = (from c in context.ProfessionalWinBids
                                        where c.ProID == bidderid
                                        && c.BidID == previousbidid
                                        select c).FirstOrDefault();;
                if (previouswinnerbid != null)
                {
                     context.DeleteObject(previouswinnerbid);
                }
               
            }

            context.SaveChanges();
      
     
    }

    public void AddNewBidderWin(SidejobEntities context, int projectId)
    {
        var newBid = GetCurrentNewBid(projectId, NewProID);
        if (newBid == null) return;
        try
        {        
            var newwin = new ProfessionalWinBid
                         {
                             BidID = newBid.BidID,
                             ProID = NewProID,
                             NumberofBids = GetNumberofBids(context)
                         };
        context.AddToProfessionalWinBids(newwin);
        context.SaveChanges();

        }
        catch (Exception e)
        {
                
            var i = e;
        }

    }

    public void DeleteFromResponseDelay(SidejobEntities context)
    {
        var rd = (from c in context.ResponseDelays
                  where c.ProjectID == ProjectID
                  select c).FirstOrDefault();

        if ( rd != null)
        {
            context.DeleteObject(rd);
            context.SaveChanges();
        }
    }

    public Bid GetCurrentNewBid(int projectid, int professionalid)
    {
        using (var context = new SidejobEntities())
        {
            var newbid = (from c in context.Bids
                          where c.ProjectID == projectid && c.BidderID == professionalid
                          orderby c.AmountOffered
                          select c).FirstOrDefault();
            return newbid;

        }
    }

    public ProfessionalGeneral2 GetProfessional()
    {
        using (var context = new SidejobEntities())
        {
            return (ProfessionalGeneral2)(from c in context.ProfessionalGeneral2
                                  where c.ProID == NewProID
                                  select c).FirstOrDefault();
        }
    }

    private int GetNumberofBids(SidejobEntities context)
    {
        var c = (from p in context.ProfessionalWinBids
                 where p.ProID == NewProID
                 select p).Count();
        return c + 1;
    }   

}