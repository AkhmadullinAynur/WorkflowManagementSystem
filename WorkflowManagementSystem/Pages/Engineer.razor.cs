using System;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Engineer
    {
        protected override void OnInitialized()
        {
            project.projects = MongoDataBase.GetProjectList();
        }

        private void StartBuild(int number)
        {
            string name = client.SurName + " " + client.Name;
            MongoDataBase.PerformerOfWork(number, name);
            MongoDataBase.StartDate(number, DateTime.Now);
            OnInitialized();
        }
        private void FinishBuild(int number)
        {
            MongoDataBase.FinishBuild(number, true);
            MongoDataBase.FinishDate(number, DateTime.Now);
            OnInitialized();
        }
    }
}