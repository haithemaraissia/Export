﻿using System;
using System.Globalization;
using System.Threading;

namespace EmailTemplates.Professional
{
    public partial class EmailTemplatesProfessionalProfessionalReminder : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            var lang = Request.QueryString["l"];
            if (lang != null | !string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Session["LCID"] = ScheduleUtility.GetLCID(lang);
            }
            else
            {
                if (Session["LCID"] != null)
                {
                    Thread.CurrentThread.CurrentUICulture =
                        new CultureInfo(ScheduleUtility.GetLanguage(Convert.ToInt32(Session["LCID"])));
                    Thread.CurrentThread.CurrentCulture =
                        CultureInfo.CreateSpecificCulture(ScheduleUtility.GetLanguage(Convert.ToInt32(Session["LCID"])));
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LCID"] == null)
            {
                Session["LCID"] = 1;
            }
            MessageProperties();
        }

        protected void MessageProperties()
        {
            const string singlespace = " ";
            var project = Request.QueryString["prid"];
            if (project != null)
            {
                ProjectLabel.Text = project;
            }
            var username = Request.QueryString["usn"];
            if (username != null)
            {
                UsernameLabel.Text = username;
            }
            var reminder = Request.QueryString["rem"];
            if (reminder != null)
            {
                switch (reminder)
                {
                    case "1":
                        ReminderLabel.Text = Resources.Resource.First;
                        break;

                    case "2":
                        ReminderLabel.Text = Resources.Resource.Second;
                        break;

                    case "3":
                        ReminderLabel.Text = Resources.Resource.Final;
                        break;

                    default:
                        ReminderLabel.Text = Resources.Resource.First;
                        break;

                }

            }

            ProjectNotification.Text = Resources.Resource.Project + singlespace + project + singlespace + Resources.Resource.Reminder;
            ReminderFees.Text = Resources.Resource.andPayFees;

        }
    }
}