using MariGold.OpenXHTML;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Application.ViewModels.SkillsDossierViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SkillsCore.Application.Factory
{
    public class FileFactory : IFileFactory
    {
        public void CreateWordFile(UserSkillsDossierViewModel userCreated, EnterpriseViewModel userEnterprise)
        {
            WordDocument doc = new WordDocument("teste2.docx");
            
            var html = CreateHtml(userCreated);
            doc.Process(new HtmlParser(html));
            doc.Save();


            //doc.Process(new HtmlParser(html));


            //var tempPath = Path.GetTempPath();

            //using FileStream file = new FileStream(Path.Combine(tempPath, "teste.docx"), FileMode.Create, FileAccess.Write);
            //using MemoryStream mem = new MemoryStream();

            //var count = doc.Document.ChildElements.Count;

            //for (int i = 1; i < doc.Document.ChildElements.Count; i++)
            //{
            //    OpenXmlElement para = doc.Document.Body.ChildElements[i];
            //    OpenXmlElement run = para.ChildElements[i];
            //    OpenXmlElement text = run.ChildElements[i];
            //}

            //doc.Save();

        }

        private string CreateHtml(UserSkillsDossierViewModel userCreated)
        {
            var sb = new StringBuilder();
            var ci = new CultureInfo("en-US");

            sb.Append("<html>");

            //CSS Style
            sb.Append(@"
                <head>
                    <style>
                        .body {
                            width: 100%;
                        }

                        .logo {
                            width: 100%;
                            max-height: 300px;
                        }

                        .name {
                            width: 100%;
                            font-size: 30px;
                            text-align: right;
                        }

                        .carrerTitle {
                            width:100%;
                            font-size: 14px;
                            text-align: right;
                            margin: 0px 0px -10px 0px;
                        }

                        .experienceTime {
                            width: 100%;
                            font-size: 14px;
                            text-align: right;
                            margin: 0px 0px -10px 0px;
                        }

                        .birth{
                            width: 100%;
                            font-size: 14px;
                            text-align: right;
                            margin: 0px;
                        }

                        .summaryTitle {
                            width: 100%;
                            font-size: 14px;
                            text-align: center;
                            background-color: Tomato;
                        }

                        .summary {
                            width: 100%;
                            font-size: 11px;
                            text-align: justify;
                        }

                        .competencesTitle {
                            width: 100%;
                            font-size: 14px;
                            text-align: center;
                            background-color: Tomato;
                        }

                        .table {
                            width: 100%
                        }
                        
                        .tableTitle {
                            width: 100%;
                            text-align: center;
                        }

                        .td {
                            width: 50%;
                            text-align: center;
                        }

                        .jobXpTitle {
                            width: 100%;
                            font-size: 14px;
                            text-align: center;
                            background-color: Tomato;
                        }

                        .jobXp {
                            width: 100%;
                            font-size: 11px;
                            text-align: justify;
                        }

                        .jobHeader {
                            text-align: right !important;
                        }

                        .languageTblHead {
                            border-bottom: 1px solid gray;
                            border-left: 1px solid gray;
                            border-right: 1px solid gray;
                            text-align: center;
                            vertical-align: middle;
                        }

                        .languageTblName {
                            border-top: 1px solid gray;
                            border-bottom: 1px solid gray;
                            border-right: 1px solid gray;
                            text-align: center;
                            vertical-align: middle;
                        }

                        .languageTblLevel {
                            border: 1px solid gray;
                            text-align: center;
                            vertical-align: middle;
                        }
                    </style>
                </head>"
            );
            sb.Append("<body class='body'>");

            //Cabeçalho
            sb.Append(@"
                <div width='100%' height='200px'>
                    <img src='https://www.natixis.com/upload/docs/image/png/2021-07/logonatixis.png' alt='Enterprise Logo'>
                </div>"
            );
            sb.Append(@$"
                <div>
                    <p class='name'>
                        <b>{userCreated.CompleteName.ToUpper()}</b>
                    </p>
                </div>
            ");
            sb.Append(@$"
                <div>
                    <p class='carrerTitle'>{userCreated.CarrerTitle}</p>
                </div>
            ");
            sb.Append(@$"
                 <div>
                    <p class='experienceTime'>{userCreated.ExperienceTime} Years of experience</p>
                </div>
            ");
            sb.Append(@$"
                <div>
                    <p class='birth'>{userCreated.BirthDay:dd/MM/yyyy}</p>
                </div>
            ");
            sb.Append(@"<hr>");

            //Corpo
            sb.Append(@"
                <div class='summaryTitle'>
                    <p>
                        <b>SUMMARY</b>
                    </p>
                </div>
            ");
            sb.Append(@$"
                <br>
                <div class='summary'>
                    <p>{userCreated.Summary}</p>
                </div>
            ");

            sb.Append(@"
                <div class='competencesTitle'>
                    <p>
                        <b>COMPETENCES</b>
                    </p>
                </div>
            ");

            sb.Append(@"
                <div>
                    <table class='table'>
                        <thead class='tableTitle'>
                            <tr>
                                <th colspan='2'>
                                    Programming
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class='td'>
                                    Technology
                                </td>
                                <td class='td'>
                                    Time
                                </td>
                            </tr>");
                        for (int i = 0; i < userCreated.Competence.Count; i++)
                        {
                            sb.Append(
                            @$"<tr>
                                <td class='td'>
                                    {userCreated.Competence[i].CompetenceName}
                                </td>
                                <td class='td'>
                                    {userCreated.Competence[i].CompetenceExperienceTime}
                                </td>
                            </tr>");
                        }
            sb.Append(@"</tbody>
                    </table>
                </div>
            ");

            sb.Append(@"
                <br>
                <div class='jobXpTitle'>
                    <p>
                        <b>JOB EXPERIENCE</b>
                    </p>
                </div>
            ");
            for (int i = 0; i < userCreated.JobExperience.Count; i++)
            {
                if (i != 0)
                    sb.Append("<hr style='margin:0px 0px -200px 0; padding:0;'>");

                sb.Append(@$"
                    <div class='jobXp'>
                        <p class='jobHeader'>
                            <b>{userCreated.JobExperience[i].EnterpriseName} - {userCreated.JobExperience[i].JobTitle}</b>
                        </p>
                        <hr style='margin:0; padding:0;'>
                        <p style='text-align: right;'>{userCreated.JobExperience[i].BeginDate:Y} - {userCreated.JobExperience[i].FinalDate:Y}</p>
                        <p><b>Project Context:</b>
                        <p>{userCreated.JobExperience[i].ProjectDescription}</p>
                        <p><b>Main Activities:</b>
                        <p>{userCreated.JobExperience[i].ProjectResponsabilities}</p>
                        <p><b>Technologies:</b>
                        <p>{userCreated.JobExperience[i].TecnologiesUsed}</p>
                    </div>
                ");
            }

            sb.Append(@"
                <br>
                <div class='jobXpTitle'>
                    <p>
                        <b>LANGUAGE</b>
                    </p>
                </div>
            ");

            sb.Append(@"
                <br>
                <div style='width:100%;'>
                    <table style='width:100%;'>
                        <thead>
                            <tr>
                                <th>
                                </th>
                                <th class='languageTblHead'>
                                    Understanding
                                </th>
                                <th class='languageTblHead'>
                                    Speaking
                                </th>
                                <th class='languageTblHead' style='border-right: 1px solid white !important'>
                                    Writing
                                </th>
                            </tr>
                        </thead>
                        <tbody>");
                    for (int j = 0; j < userCreated.Language.Count; j++)
                    {
                        sb.Append(@$"
                            <tr>
                                <td class='languageTblName' style='padding-top: 5px;'>
                                    {userCreated.Language[j].LanguageName}
                                </td>
                                <td class='languageTblLevel'>
                                    {userCreated.Language[j].LanguageUnderstanding}
                                </td>
                                <td class='languageTblLevel'>
                                    {userCreated.Language[j].LanguageSpeaking}
                                </td>
                                <td class='languageTblLevel' style='border-right: 1px solid white !important'>
                                    {userCreated.Language[j].LanguageWriting}
                                </td>
                            </tr>");
                    }
            sb.Append(@"</tbody>
                    </table>
                </div>
            ");

            sb.Append(@"
                <br>
                <div class='jobXpTitle'>
                    <p>
                        <b>EDUCATION</b>
                    </p>
                </div>
            ");

            sb.Append(@"
                <div>
            ");
            for (int f = 0; f < userCreated.AcademicFormation.Count; f++)
            {
                sb.Append(@$"
                    <p>{userCreated.AcademicFormation[f].ConclusionDate.Year} ({ci.DateTimeFormat.GetMonthName(userCreated.AcademicFormation[f].ConclusionDate.Month)}) - {userCreated.AcademicFormation[f].CourseTitle} by {userCreated.AcademicFormation[f].InstituitionName}</p>
                ");
            }
            sb.Append(@"
                </div>
            ");

            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }
    }
}
