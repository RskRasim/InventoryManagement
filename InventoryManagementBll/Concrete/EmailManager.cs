using InventoryManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBll.Concrete
{
    public class EmailManager : IEmail
    {
        public void SendMail(string Email,string CompanyName)
        {

           
            var client = new SmtpClient();
            var credential = new NetworkCredential
            {
                UserName = "Rasim.senyuz@gmail.com",
                Password = "******"
            };
            client.Credentials = credential;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.BodyEncoding = Encoding.UTF8;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("Rasim.senyuz@gmail.com");
            msg.To.Add(Email);
            msg.Subject = "Elbow Contact";
            #region Email Template
            msg.Body = "<html> " +
                "<head>" +
                "</head>" +
                "<body>" +

                   "<div style ='background-color:transparent;'>" +




        "<div class='block-grid two-up no-stack' style='Margin: 0 auto; min-width: 320px; max-width: 650px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;;'>"+
            "<div style = 'border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;' >"+
                "<div class='col num6' style='min-width: 320px; max-width: 325px; display: table-cell; vertical-align: top;'>" +
                "<div style = 'width:100% !important;' >" +
                "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:25px; padding-bottom:25px; padding-right: 0px; padding-left: 25px;'><div align='left' class='img-container left fixedwidth' style='padding-right: 0px;padding-left: 0px;'>" +
               "<span style='font-size:24px; font-family:Verdana;'>Elbow Contact</span>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='col num6' style='min-width: 320px; max-width: 325px; display: table-cell; vertical-align: top;;'>"+
                    "<div style = 'width:100% !important;'>"+
                        "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:25px; padding-bottom:25px; padding-right: 25px; padding-left: 0px;'>"+
                            "<div align = 'right' class='button-container' style='padding-top:10px;padding-right:0px;padding-bottom:10px;padding-left:10px;'><span style = 'font-size: 16px; line-height: 32px;' ><span style='font-size: 14px; line-height: 28px;'>My account</span></span></div>"+
                        "</div>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>"+
    "</div>"+




    "<div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 650px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #D6E7F0;'>" +
    "<div style = 'border-collapse: collapse;display: table;width: 100%;background-color:#17A2B8;' >" +
        "<div class='col num12' style='min-width: 320px; max-width: 650px; display: table-cell; vertical-align: top;'>" +
        "<div style = 'width:100% !important;'>" +
        "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:60px; padding-right: 25px; padding-left: 25px;'>" +
            "<div style = 'color:#052d3d;font-family:'Roboto', Tahoma, Verdana, Segoe, sans-serif;line-height:150%;padding-top:20px;padding-right:10px; text-align:left;padding-bottom:0px;padding-left:15px;'>" +
    "<div style = 'font-size: 12px; line-height: 18px; font-family: 'Roboto', Tahoma, Verdana, Segoe, sans-serif; color: #052d3d;'> <p style = 'font-size: 14px; line-height: 75px; text-align: center; margin: 0;' ><span style='font-size: 50px;'><strong><span style = 'line-height: 75px; font-size: 50px;' ><span style='font-size: 38px; line-height: 57px;'>Hoşgeldin</span></span></strong></span></p><p style = 'font-size: 14px; line-height: 51px; text-align: center; margin: 0;' ><span style='font-size: 34px;'><strong><span style = 'line-height: 51px; font-size: 34px;' ><span style='color: #2190e3; line-height: 51px; font-size: 34px;'>" + CompanyName + "</span></span></strong></span></p></div></div><div style = 'color:#555555;font-family:'Ariel', Tahoma, Verdana, Segoe, sans-serif;line-height:120%;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;'><div style = 'font-size: 12px; line-height: 14px; text-align:left; font-family: 'Roboto', Tahoma, Verdana, Segoe, sans-serif; color: #555555;'><p style = 'font-size: 14px; line-height: 21px; text-align: center; margin: 0;' ><span style='font-size: 18px; color: #000000;'>Merhaba öncelikle bizi tercih ettiğiniz için size teşekkür ederiz.bu bizi çok memnunun etti.bu cümle size çok kilişe gelicek biliyoruz fakat zamanla bizi tanıyacak ve daha çok seviceksin.sizi tutmayalım işiniz vardır.</br> Kolay gelsin.</br> Saygılarımızla</br> Elbow Contact Ailesi </span></p></div></div> <div align = 'center' class='button-container' style='padding-top:20px;padding-right:10px;padding-bottom:10px;padding-left:10px;'><span style = 'font-size: 16px; line-height: 32px;' ><strong> Giriş Yap</strong></span></span></a></div></div></div></div></div></div></div>" +
                    "<div style = 'background-color:transparent;' >" +
                        "<div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 650px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;;'>" +

                            "<div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'>" +
                                "<div class='col num12' style='min-width: 320px; max-width: 650px; display: table-cell; vertical-align: top;;'>" +
                                   "<div style = 'width:100% !important;'>" +
                                        "<div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:20px; padding-bottom:60px; padding-right: 0px; padding-left: 0px;'>" +
                                           " <table cellpadding = '0' cellspacing='0' class='social_icons' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt;' valign='top' width='100%'>" +
                                                "<tbody>" +
                                                    "<tr style = 'vertical-align: top;' valign='top'>" +
                                                       " <td style = 'word-break: break-word; vertical-align: top; padding-top: 10px; padding-right: 10px; padding-bottom: 10px; padding-left: 10px; border-collapse: collapse;' valign='top'>" +
                                                            "<table activate = 'activate' align='center' alignment='alignment' cellpadding='0' cellspacing='0' class='social_table' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: undefined; mso-table-tspace: 0; mso-table-rspace: 0; mso-table-bspace: 0; mso-table-lspace: 0;' to='to' valign='top'>" +
                                                               " <tbody>" +
                                                                   " <tr align = 'center' style='vertical-align: top; display: inline-block; text-align: center;' valign='top'>" +
                                                                        "<td style = 'word-break: break-word; vertical-align: top; padding-bottom: 5px; padding-right: 8px; padding-left: 8px; border-collapse: collapse;' valign='top'><a href = 'https://www.facebook.com/' target='_blank'><img alt = 'Facebook' height='32' src='images/facebook@2x.png' style='outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; clear: both; height: auto; float: none; border: none; display: block;' title='Facebook' width='32' /></a></td>" +
                                                                        "<td style = 'word-break: break-word; vertical-align: top; padding-bottom: 5px; padding-right: 8px; padding-left: 8px; border-collapse: collapse;' valign='top'><a href = 'https://twitter.com/' target='_blank'><img alt = 'Twitter' height='32' src='images/twitter@2x.png' style='outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; clear: both; height: auto; float: none; border: none; display: block;' title='Twitter' width='32' /></a></td>" +
                                                                        "<td style = 'word-break: break-word; vertical-align: top; padding-bottom: 5px; padding-right: 8px; padding-left: 8px; border-collapse: collapse;' valign='top'><a href = 'https://instagram.com/' target='_blank'><img alt = 'Instagram' height='32' src='images/instagram@2x.png' style='outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; clear: both; height: auto; float: none; border: none; display: block;' title='Instagram' width='32' /></a></td>" +
                                                                        "<td style = 'word-break: break-word; vertical-align: top; padding-bottom: 5px; padding-right: 8px; padding-left: 8px; border-collapse: collapse;' valign='top'><a href = 'https://www.pinterest.com/' target='_blank'><img alt = 'Pinterest' height='32' src='images/pinterest@2x.png' style='outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; clear: both; height: auto; float: none; border: none; display: block;' title='Pinterest' width='32' /></a></td>" +
                                                                    "</tr>" +
                                                               " </tbody>" +
                                                            "</table>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                "</tbody>" +
                                            "</table>" +
                                           " <div style = 'color:#555555;font-family:'Lato', Tahoma, Verdana, Segoe, sans-serif;line-height:150%;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;'>" +
                                               " <div style = 'font-size: 12px; line-height: 18px; font-family: 'Lato', Tahoma, Verdana, Segoe, sans-serif; color: #555555;'>" +
                                                  "  <p style = 'font-size: 14px; line-height: 21px; text-align: center; margin: 0;' > Elbow Contact</p>" +
                                                  "  <p style = 'font-size: 14px; line-height: 21px; text-align: center; margin: 0;' > İstanbul / Türkiye </ p >" +
                                              " </div >" +
                                          "  </div >" +
                                               " <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'>" +
                                                   "<tbody>" +
                                                  "  <tr style = 'vertical-align: top;' valign='top'>" +
                                                       " <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 10px; padding-right: 10px; padding-bottom: 10px; padding-left: 10px; border-collapse: collapse;' valign='top'>" +
                                                            "<table align = 'center' border='0' cellpadding='0' cellspacing='0' class='divider_content' height='0' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 60%; border-top: 1px dotted #C4C4C4; height: 0px;' valign='top' width='60%'>" +
                                                               " <tbody>" +
                                                                "    <tr style = 'vertical-align: top;' valign='top'>" +
                                                                       " <td height = '0' style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; border-collapse: collapse;' valign='top'><span></span></td>" +
                                                                 "   </tr>" +
                                                                "</tbody>" +
                                                           " </table>" +
                                                      "  </td>" +
                                                   " </tr>" +
                                                "</tbody>" +
                                            "</table>" +
                                           " <div style = 'color:#4F4F4F;font-family:'Lato', Tahoma, Verdana, Segoe, sans-serif;line-height:120%;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;' >" +

                                                " <div style = 'font-size: 12px; line-height: 14px; font-family: 'Lato', Tahoma, Verdana, Segoe, sans-serif; color: #4F4F4F;' >" +

                                                    "  <p style = 'font-size: 12px; line-height: 16px; text-align: center; margin: 0;' ><span style = 'font-size: 14px;' ><a href = '#' rel = 'noopener' style = 'text-decoration: none; color: #2190E3;' target = '_blank' ><strong > Help & amp; FAQ's</strong></a> |  <strong><a href='#' rel='noopener' style='text-decoration: none; color: #2190E3;' target='_blank'>Returns</a> </strong> |  <span style='background-color: transparent; line-height: 16px; font-size: 14px;'>1-998-9283-19832</span></span></p>" +
                                               " </div >" +

                                                               "</div >" +

                                                           "</div >" +

                                                      "</div >" +

                                                  " </div >" +

                                              " </div >" +

                                          " </div>" +

                                       "</div>" +

                                   "</td>" +

                               "</tr>" +

                           "</tbody>" +

                       "</table>" +
                   "</body >" +
                   "</html>"; ;
            #endregion 


            client.Send(msg);
        }
    }
}


