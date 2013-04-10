using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SidejobModel;

/// <summary>
/// Summary description for PaymentProcessUpdate
/// </summary>
public static class PaymentProcessUpdate
{


    /// <summary>
    /// Common to both bidder and poster to invoke the routine
    /// </summary>
    /// <param name="projectid"></param>
    /// <param name="payerid"></param>
    /// <param name="payerole"></param>
    public static void  PaymentUpdateProcedure(int projectid, int payerid, string payerole)
    {
        //Determine the role in ClosedProject
        using (var context = new SidejobEntities())
        {
            var closed = (from c in context.ClosedProjects
                          where c.ProjectID == projectid
                          select c).FirstOrDefault();
            if (closed != null)
            {
                if (closed.PosterID == payerid && closed.PosterRole == payerole)
                {
                    //poster
                    PosterSuccessPayment(projectid, 4);
                }

                if (closed.BidderID == payerid && closed.BidderRole == payerole)
                {
                    //bidder
                    BidderSuccessPayment(projectid, 2);
                }
            }
        }
    }



    /// <summary>
    /// Bidder Update for both scheduling procedure:
    /// TimeUp
    /// ResponseDelay
    /// </summary>
    /// <param name="projectid"></param>
    /// <param name="professionalid"></param>
    /// <param name="actionid"></param>
    public static void BidderSuccessPayment(int projectid,  int actionid)
    {
        BidderTimeUpUpdate(projectid, actionid);
        BidderResponseDelayUpdate(projectid);
    }

    public static void BidderTimeUpUpdate(int projectid, int actionid)
    {
        using (var context = new SidejobEntities())
        {
            var cp = (from c in context.ClosedProjects
                      where c.ProjectID == projectid
                      select c).FirstOrDefault();
            if (cp != null)
            {
                var timeupUpdate = new TimeUp(projectid, actionid, cp);
            }
        }
    }

    public static void BidderResponseDelayUpdate(int projectid)
    {
        using (var context = new SidejobEntities())
        {
            var rd = (from c in context.ResponseDelays
                      where c.ProjectID == projectid
                      select c).FirstOrDefault();
            if (rd != null)
            {
                rd.Status = 4;
                context.SaveChanges();
            }
        }
    }


    /// <summary>
    /// Poster Update for both scheduling procedure:
    /// TimeUp
    /// ResponseDelay
    /// </summary>
    /// <param name="projectid"></param>
    /// <param name="actionid"></param>

    public static void PosterSuccessPayment(int projectid, int actionid)
    {
        PosterTimeUpUpdate(projectid, actionid);
        PosterResponseDelayUpdate(projectid);
    }

    public static void PosterTimeUpUpdate(int projectid, int actionid)
    {
        using (var context = new SidejobEntities())
        {
            var cp = (from c in context.ClosedProjects
                      where c.ProjectID == projectid
                      select c).FirstOrDefault();
            if (cp != null)
            {
                var timeupUpdate = new TimeUp(projectid, actionid, cp);
            }

        }
    }

    public static void PosterResponseDelayUpdate(int projectid)
    {
        using (var context = new SidejobEntities())
        {
            var rd = (from c in context.ResponseDelays
                      where c.ProjectID == projectid
                      select c).FirstOrDefault();
            context.DeleteObject(rd);
        }
    }
}



