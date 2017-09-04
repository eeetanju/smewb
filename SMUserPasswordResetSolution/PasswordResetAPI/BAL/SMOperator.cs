using PasswordResetAPI.SMServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordResetAPI.BAL
{
    public class SMOperator
    {
        public String ResetOperatorPass(string opName)
        {
            string result;
            try
            {
                PassResetOperatorClient client = new PassResetOperatorClient();
                PassResetOperatorKeysType keys = new PassResetOperatorKeysType();
                PassResetOperatorModelType models = new PassResetOperatorModelType();
                SavePassResetOperatorRequest req = new SavePassResetOperatorRequest();
                SavePassResetOperatorResponse res = new SavePassResetOperatorResponse();
                PassResetOperatorInstanceType instance = new PassResetOperatorInstanceType();
                StringType stringType = new StringType();
                stringType.Value = opName;
                instance.UserName = stringType;
                stringType.Value = opName;
                keys.UserName = stringType; ;
                client.ClientCredentials.UserName.UserName = "falcon";
                //client.ClientCredentials.UserName.Password = "@1qa@1qa";
                // client.Open();
                models.keys = keys;
                models.instance = instance;
                req.model = models;
                string r = req.ToString();
                res = client.SavePassResetOperator(req);
                result = res.returnCode == 0 ? "OK" : "NOK";
               //result=checkResponse(res);
                client.InnerChannel.Close();
                //client.Close(); 
                //TextBox2.Text = GetMessage(res.messages);

            }
            catch (Exception excp)
            {
                result = excp.ToString();
            }
  
            
                return result;
            
        }

        private string checkResponse(SavePassResetOperatorResponse response)
        {
            String result = GetMessage(response.messages);
            return result;
            if (response.model.instance.Email != null)
            { }
               /* if (result == "true")
                {
                    UpdatePanelMessage.Visible = true;
                    PanelUserID.Visible = false; MessageLabel.Visible = true;
                    MessageLabel.Text = "Yeni Şifreniz \"" + response.model.instance.Email.Value + "\" adresine gönderilimiştir.";
                }
                else if (result.ToUpper() == "LDAP")
                {
                    UpdatePanelMessage.Visible = true;
                    PanelUserID.Visible = false; MessageLabel.Visible = true;
                    MessageLabel.Text = "LDAP üzerinden yetkilendirmeniz bulunmaktadır . Lütfen Active Directory'den şifrenizi resetleyiniz";
                }
                else
                {
                    UpdatePanelMessage.Visible = true;
                    PanelUserID.Visible = false; MessageLabel.Visible = true;
                    MessageLabel.Text = "Geçici bir sorun nedeni ile şifreniz sıfırlanamamıştır. Lütfen tekrar deneyiniz";
                }
            }
            else
            {
                UpdatePanelMessage.Visible = true;
                PanelUserID.Visible = false; MessageLabel.Visible = true;
                MessageLabel.Text = "Girilen \"" + TextBoxUserID.Text + "\" Kullanıcısı Bulunamamaktadır. Lütfen kullanıcı adınızı kontrol ediniz.";
            }*/
        }
        public string GetMessage(MessageType[] messages)
        {
            try
            {
                foreach (MessageType val in messages)
                {
                    if (val.Value.ToString().Split(':')[0].ToUpper() == "RETURNCODE ")
                    {
                        return val.Value.ToString().Split(':')[1];
                    }
                }
                return "false";
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

    }
}
