using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Unity;

namespace OCBCDemo.WebApplication.Utility
{
    public class VerifyCodeHelper
    {
        /// <summary>
        /// Generate verification code picture consists of 5 random letters with confusing background 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Bitmap CreateVerifyCode(out string code)
        {
            //Step1: Create Bitmap object
            Bitmap bitmap = new Bitmap(200, 60);
            Graphics graph = Graphics.FromImage(bitmap);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();
            string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";

            StringBuilder sb = new StringBuilder();

            //Step2: Get 5 letters randomly
            for (int x = 0; x < 5; x++)
            {
                string letter = letters.Substring(r.Next(0, letters.Length - 1), 1);
                sb.Append(letter);
                graph.DrawString(letter, font, new SolidBrush(Color.Black), x * 38, r.Next(0, 15));
            }
            code = sb.ToString();

            //Step3: Confusing background
            Pen linePen = new Pen(new SolidBrush(Color.Black), 2);
            for (int x = 0; x < 6; x++)
                graph.DrawLine(linePen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            return bitmap;
        }
    }
}