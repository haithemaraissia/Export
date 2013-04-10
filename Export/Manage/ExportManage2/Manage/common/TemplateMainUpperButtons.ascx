<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TemplateMainUpperButtons.ascx.vb"
    Inherits="TemplateMainUpperButtons" %>
<link href="http://my-side-job.com/Manage/MySideJob/Styles/Site.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="http://my-side-job.com/Manage/MySideJob/Styles/Menustyle.css" type="text/css" />
<!--[if lte IE 7]>
        <link rel="stylesheet" type="text/css" href=Styles/ie.css" media="screen" />
    <![endif]-->
<script type="text/javascript" src="http://my-side-job.com/Manage/MySideJob/Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" language="javascript" src="http://my-side-job.com/Manage/MySideJob/Scripts/jquery.dropdownPlain.js"></script>
<div id="page-wrap">
    <ul class="dropdown" style="z-index: 100">
        <li><a id="selected" href="../Home.aspx">Home</a> </li>
        <li><a href="#">User</a>
            <ul>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Customer/Customer.aspx">Customer</a>
                    <ul>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Customer/DeniedCustomer.aspx">DeniedCustomer</a></li>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Customer/LockedCustomer.aspx">LockedCustomer</a></li>
                    </ul>
                </li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Professional/Professional.aspx">Professional</a>
                    <ul>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Professional/DeniedProfessional.aspx">DeniedProfessional</a></li>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Professional/LockedProfessional.aspx">LockedProfessional</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li><a href="#">Project</a>
            <ul>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Project/Project.aspx">Project</a>
                    <ul>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Project/DeniedProject.aspx">DeniedProject</a></li>
                        <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Project/LockedProject.aspx">LockedProject</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li><a href="#">Account</a>
            <ul>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Management/Profile/ViewProfile.aspx">View Profile</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Account/EditProfile.aspx">Edit Profile</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Account/DeleteProfile.aspx">Delete Profile</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Account/ManagePhoto.aspx">Manage Photo</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Account/ChangePassword.aspx">Change Password</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/Account/LogOut.aspx">Log Out</a></li>
            </ul>
        </li>
        <li style="width: 132px"><a href="http://www.my-side-job.com/Manage/MySideJob/Help.aspx">Help</a>
            <ul>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/AboutUs.aspx">About Us</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/WhiteBoard.aspx">WhiteBoard</a></li>
                <li><a href="http://www.my-side-job.com/Manage/MySideJob/ContactUs.aspx">Contact Us</a></li>
            </ul>
        </li>
        	<li style="float:right">
        	    <a href="#">
        	         <img id="selected" alt="earth" src="http://www.my-side-job.com/Images/flags/earth.png" runat="server" height="42" width="42" />
        	     </a>
        		<ul>
        		     <li><a href="?l=en-US"><img src="http://www.my-side-job.com/Images/flags/US.png" <asp:Label ID="Label1" ForeColor="White" runat="server" Text="<%$ Resources:Resource, English %>" Font-Size="Smaller"></asp:Label>  </></a></li>
                                                <li><a href="?l=fr"><img src="http://www.my-side-job.com/Images/flags/FR.png" <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, French %>" Font-Size="Smaller"></asp:Label>  </></a></li>
                                                <li><a href="?l=es"><img src="http://www.my-side-job.com/Images/flags/ES.png"  <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, Spanish %>" Font-Size="Smaller"></asp:Label>  </></a></li>
                                                <li><a href="?l=zh-CN"><img src="http://www.my-side-job.com/Images/flags/CN.png"  <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, Chinese %>" Font-Size="Smaller"></asp:Label>  </></a></li>
                                                <li><a href="?l=ru"><img src="http://www.my-side-job.com/Images/flags/RU.png"  <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, Russian %>" Font-Size="Smaller"></asp:Label></>  </a></li>
                                                <li><a href="?l=ar"><img src="http://www.my-side-job.com/Images/flags/AE.png" <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Resource, Arabic %>" Font-Size="Smaller"></asp:Label></>  </a></li>
                                                <li><a href="?l=ja"><img src="http://www.my-side-job.com/Images/flags/JP.png" <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Resource, Japanese %>" Font-Size="Smaller"></asp:Label></>  </a></li>
                                                <li><a href="?l=de"><img src="http://www.my-side-job.com/Images/flags/DE.png" <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, German %>" Font-Size="Smaller"></asp:Label></>  </a></li>
                            </ul>
        	</li>
        </ul>
	</div>