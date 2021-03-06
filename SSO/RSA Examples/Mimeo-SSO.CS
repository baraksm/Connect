﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSOClient
{
    class Program
    {
        // Stage
        static string SamplePublicKey = "<RSAKeyValue><Modulus>kQh6bGsXV7/vY2WvLiu3N63DWRCuMuSbSL/eMh01V9NPOsQDp0DKDfUsGCxH0ahE49Ov+RuzPr4auhA40Df7qS7u8cmvh1j2vicceGMGPrcRmVrvqq/pyxcg3jF0D3L0gPhz4nA5g2mB+A1sTKULLWQY1vugVyQmKJpxB5fObKs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        static void Main(string[] args)
        {
            // Values to pass into SSO

            String firstName = EncryptToken("Raul"); //encrypted
            String lastName = EncryptToken("Moncada"); //encrypted
            String email = EncryptToken("sso-test2@company.com"); //encrypted
            String companyId = "89B9A2B4-8993-483D-BDC1-101D8CD720BE";
            String organizationId = EncryptToken("FD52E8D2-FBC9-48E9-BACE-0D8CC90448EB"); //encrypted
            String companyName = EncryptToken("My Company"); //encrypted
            String ssoVersion = "2.0";
            String redirectUrl = "https://marketplace.mimeo.com/company-sso";
            String errorUrl = "http://google.com";
            String customId = EncryptToken("");
            String initialCredit = EncryptToken("");
            String authorizedMarketPlaceUrl = "company-sso";

            Console.WriteLine("<BR>");
            //Console.WriteLine("<FORM method=\"post\" action=\"https://my.sandbox.mimeo.com/sso/authenticate.ashx\">");
            Console.WriteLine("<FORM method=\"post\" action=\"https://my.mimeo.com/sso/authenticate.ashx\">");
            Console.WriteLine("<input type=\"hidden\" name=\"firstName\" value=\"{0}\" />", firstName);
            Console.WriteLine("<input type=\"hidden\" name=\"lastName\" value=\"{0}\" />", lastName);
            Console.WriteLine("<input type=\"hidden\" name=\"email\" value=\"{0}\" />", email);
            Console.WriteLine("<input type=\"hidden\" name=\"companyId\" value=\"{0}\" />", companyId);
            Console.WriteLine("<input type=\"hidden\" name=\"organizationId\" value=\"{0}\" />", organizationId);
            Console.WriteLine("<input type=\"hidden\" name=\"companyName\" value=\"{0}\" />", companyName);
            Console.WriteLine("<input type=\"hidden\" name=\"ssoVersion\" value=\"{0}\" />", ssoVersion);
            Console.WriteLine("<input type=\"hidden\" name=\"redirectUrl\" value=\"{0}\" />", redirectUrl);
            Console.WriteLine("<input type=\"hidden\" name=\"errorUrl\" value=\"{0}\" />", errorUrl);
            Console.WriteLine("<input type=\"hidden\" name=\"customId\" value=\"{0}\" />", customId);
            Console.WriteLine("<input type=\"hidden\" name=\"initialCredit\" value=\"{0}\" />", initialCredit);
            Console.WriteLine("<input type=\"hidden\" name=\"authorizedMarketPlaceUrl\" value=\"{0}\" />", authorizedMarketPlaceUrl);

            Console.WriteLine(" <input type=\"submit\" value=\"Submit\" />");
            Console.WriteLine(" </FORM>");

        }

        static string EncryptToken(string token)
        {
            string encryptedToken;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(SamplePublicKey);
                byte[] encryptedTokenData = rsa.Encrypt(new ASCIIEncoding().GetBytes(token), false);

                encryptedToken = Convert.ToBase64String(encryptedTokenData, 0, encryptedTokenData.Length);

            }

            return encryptedToken;
        }
        
        
    }
}
