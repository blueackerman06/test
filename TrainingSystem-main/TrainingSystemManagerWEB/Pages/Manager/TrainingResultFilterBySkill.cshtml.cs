using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TrainingSystemManagerWEB.Pages.Manager
{
    public class TrainingResultFilterBySkillModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public int SkillID { get; set; }
        public List<EvaluateDto> TrainingResults { get; set; }
        public List<Skill> ListSkill { get; set; }
        public List<Knowledge> ListKnowledge { get; set; }
        public List<JobPosition> ListJobPosition { get; set; }
        public void GetListSkill()
        {
            var url = "https://localhost:5001/api/skill";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListSkill = JsonConvert.DeserializeObject<List<Skill>>(messageTask.Result);
        }

        public void GetTrainingResults()
        {
            var urlTrainingProgram = "https://localhost:5001/api/course-participant/skill/";
            var responseTaskTrainingProgram = client.GetAsync(urlTrainingProgram + SkillID);
            responseTaskTrainingProgram.Wait();
            HttpResponseMessage resultTrainingProgram = responseTaskTrainingProgram.Result;
            if (resultTrainingProgram.IsSuccessStatusCode)
            {
                var messageTask = resultTrainingProgram.Content.ReadAsStringAsync();
                messageTask.Wait();
                TrainingResults = JsonConvert.DeserializeObject<List<EvaluateDto>>(messageTask.Result);
            }
        }

        public void GetListKnowledge()
        {
            var url = "https://localhost:5001/api/knowledge";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListKnowledge = JsonConvert.DeserializeObject<List<Knowledge>>(messageTask.Result);
        }

        public void GetListJobPosition()
        {
            var url = "https://localhost:5001/api/job-position";
            var response = client.GetAsync(url);
            response.Wait();
            HttpResponseMessage result = response.Result;
            var messageTask = result.Content.ReadAsStringAsync();
            messageTask.Wait();
            ListJobPosition = JsonConvert.DeserializeObject<List<JobPosition>>(messageTask.Result);
        }

        public void OnGet()
        {
            SkillID = Int32.Parse((string)RouteData.Values["SkillID"]);

            GetListKnowledge();
            GetListSkill();
            GetTrainingResults();
            GetListJobPosition();
        }
    }
}
