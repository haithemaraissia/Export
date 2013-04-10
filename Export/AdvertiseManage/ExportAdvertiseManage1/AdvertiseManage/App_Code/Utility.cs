using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using SidejobModel;

public static class Utility
{
    public static string Login()
    {
        return string.Format("~/Account/Login.aspx?ReturnUrl={0}", HttpContext.Current.Request.Url.AbsoluteUri);
    }

    public static string GetZipcode(int countryID, int regionID, string cityName, string zipcode)
    {
        var selectedZipCode = "";
        using (var context = new SidejobEntities())
        {
            try
            {
                var queryRegion = from r in context.regionsUpdates
                                  where r.CountryId == countryID && r.RegionId == regionID
                                  select r.Code;
                var regioncode = queryRegion.FirstOrDefault();

                if (countryID == 254)
                {
                    var queryZipcode = from c in context.USAZipCodes
                                       where (c.City == cityName && c.PostalCodeID == Convert.ToInt32(zipcode) && c.State == regioncode)
                                       select c.PostalCodeID;
                    try
                    {
                        selectedZipCode = queryZipcode.FirstOrDefault().ToString(CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {

                        selectedZipCode = "";
                    }

                    if (selectedZipCode == "")
                    {

                        var defaultqueryzipcode = from c in context.USAZipCodes
                                                  where (c.City == cityName && c.State == regioncode)
                                                  select c.PostalCodeID;

                        selectedZipCode = defaultqueryzipcode.FirstOrDefault().ToString(CultureInfo.InvariantCulture);
                    }
                }
                if (countryID == 43)
                {
                    var queryZipcode = from c in context.CanadaZipCodes
                                       where (c.City == cityName && c.PostalCode == zipcode && c.ProvinceCode == regioncode)
                                       select c.PostalCodeID;
                    try
                    {
                        selectedZipCode = queryZipcode.FirstOrDefault().ToString(CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {

                        selectedZipCode = "";
                    }
                    if (selectedZipCode == "")
                    {

                        var defaultqueryzipcode = from c in context.CanadaZipCodes
                                                  where (c.City == cityName && c.ProvinceCode == regioncode)
                                                  select c.PostalCode;

                        selectedZipCode = defaultqueryzipcode.First();
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        if (selectedZipCode == "")
        {
            selectedZipCode = "0";
        }
        return selectedZipCode;
    }

    public static int GetLCID(string lang)
    {
        switch (lang)
        {

            case "en-US":
                return 1;

                break;
            case "fr":
                return 2;

                break;
            case "es":
                return 3;

                break;
            case "zh-CN":
                return 4;

                break;
            case "ru":
                return 5;

                break;
            case "ar":
                return 6;

                break;
            case "ja":
                return 7;

                break;
            case "de":
                return 8;
                break;

            default:
                return 1;
                break;
        }

    }

    public static string GetLanguage(int langid)
    {
        switch (langid)
        {

            case 1:
                return "en-US";

                break;
            case 2:
                return "fr";

                break;
            case 3:
                return "es";

                break;
            case 4:
                return "zh-CN";

                break;
            case 5:
                return "ru";

                break;
            case 6:
                return "ar";

                break;
            case 7:
                return "ja";

                break;
            case 8:
                return "de";
                break;

            default:
                return "en-US";
                break;
        }

    }

    public static string GetCurrentLCID(string lang)
    {
        if (lang != null | !string.IsNullOrEmpty(lang))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(GetLanguage(Convert.ToInt32(lang)));
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(GetLanguage(Convert.ToInt32(lang)));
            return GetLCID(lang).ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            return GetLanguage(1);
        }

    }

    public static string GetIndustryById(int industryId, int lcid)
    {
        var resultcode = "";
        IQueryable<string> result;
        using (var context = new SidejobEntities())
        {
            switch (lcid)
            {
                case 1:
                    result = from c in context.Categories
                             where c.CategoryID == industryId
                             select c.CategoryName;
                    break;

                case 2:
                    result = from c in context.CategoriesFrs
                             where c.CategoryID == industryId
                             select c.CategoryName;
                    break;

                case 3:
                    result = from c in context.CategoriesSps
                             where c.CategoryID == industryId
                             select c.CategoryName;
                    break;
                default:
                    result = from c in context.Categories
                             where c.CategoryID == industryId
                             select c.CategoryName;
                    break;
            }
            resultcode = result.ToList().FirstOrDefault();
        }


        return resultcode;
    }

    public static string GetFlagPath(int countryID)
    {
        using (var context = new SidejobEntities())
        {
            var result = from c in context.CountriesUpdates
                         where c.CountryId == countryID
                         select c.Path;
            return result.FirstOrDefault();
        }
    }

}

