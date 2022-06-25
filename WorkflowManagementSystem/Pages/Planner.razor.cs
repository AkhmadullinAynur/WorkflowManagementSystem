using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Planner
    {
        List<Product> product;

        private int _numberProject;
        private string _nameProject;
        private string _nameComponent;
        private int _quantity;
        private int _article;

        private string _nameTask;

        public string Value { get; set; }

        private bool _isEditActiv;
        private bool _isEditActivPanel;
        private bool _isNewProjectActive;
        private bool _isNewProject;
        private bool _isRegComplete;
        private bool _isEditComplete;
        private bool _countEditActive;
        private bool _addTaskActive;
        private bool _addTaskComplete;

        private void IsNewproject()
        {
            Refrash();
            MessageFalse();
            _numberProject = 99;
            foreach (var item in project.projects)
            {
                _numberProject = item.NumberProject;
            }
            int number = _numberProject;
            for (int i = 100; i <= number + 1; i++)
            {
                _numberProject = i;
            }
            _isNewProject = !_isNewProject;
            _isRegComplete = false;
            _isEditActiv = false;
            _isEditComplete = false;
            _isNewProjectActive = !_isNewProjectActive;
        }

        private void IsEditActiv(int number)
        {
            Refrash();
            MessageFalse();
            project.newProjects = MongoDataBase.FindProject(number);
            foreach (var item in project.newProjects)
            {
                _numberProject = item.NumberProject;
                _nameProject = item.NameProject;
            }
            productList.newProductList = MongoDataBase.GetComponentList(_numberProject);
            taskList.newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
            _isEditActiv = true;
            _isEditActivPanel = true;
            _isNewProjectActive = true;
            _isNewProject = false;
            _countEditActive = false;
            _addTaskActive = false;
            OnInitialized();
        }
        private void AddTaskActive()
        {
            MessageFalse();
            _addTaskActive = !_addTaskActive;
            _isNewProjectActive = true;
        }

        private void Cancel()
        {
            Refrash();
            _isEditActiv = false;
            _isEditActivPanel = false;
            _isNewProjectActive = false;
            _isNewProject = false;
            _countEditActive = false;
            _addTaskActive = false;
        }
        private void MessageFalse()
        {
            _isRegComplete = false;
            _isEditComplete = false;
            _addTaskComplete = false;
        }
        private void CancelEditCount()
        {
            if (_isNewProject)
            {
                _isNewProject = true;
                _countEditActive = false;
            }
            else
            {
                _isEditActivPanel = true;
                _countEditActive = false;
            }
        }
        private void Refrash()
        {
            taskList.newTaskList = new List<TaskList>();
            productList.newProductList = new List<Product>();
            productList.getProductList = MongoDataBase.GetProductList();
            _nameProject = string.Empty;
        }

        protected override void OnInitialized()
        {
            project.projects = MongoDataBase.GetProjectList();
            taskList.getTaskLists = MongoDataBase.GetTaskList();
        }
        private void ReplaceProduct()
        {
            foreach (var item in productList.newProductList)
            {
                var component = productList.getProductList.Find(x => x.Article == item.Article);
                if (component != null)
                {
                    MongoDataBase.ReplaceProduct(item.Article, component);
                }
            }
            OnInitialized();
        }
        private void AddProjectToDataBase()
        {
            if (_nameProject != null)
            {
                MongoDataBase.AddProjectToDB(new Project(_numberProject, _nameProject, taskList.newTaskList, productList.newProductList));
                ReplaceProduct();
                _isRegComplete = !_isRegComplete;
                Cancel();
            }
        }
        private void FinishEdit()
        {
            _isEditComplete = !_isEditComplete;
            MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, taskList.newTaskList, productList.newProductList));
            ReplaceProduct();
            Refrash();
            Cancel();
        }
        private void DeleteProject(int number)
        {
            MessageFalse();
            MongoDataBase.DeleteProject(number);
            Cancel();
            OnInitialized();
        }

        private void SelectionTask(ChangeEventArgs args)
        {
            var buffTasks = taskList.getTaskLists.Find(x => x.NameTask == args.Value.ToString());
            _nameTask = buffTasks.NameTask;
            var task = taskList.newTaskList.Find(x => x.NameTask == _nameTask);
            if (task == null)
            {
                taskList.newTaskList.Add(buffTasks);
            }
        }
        private void SelectionComponent(ChangeEventArgs args)
        {

            var buffComponent = productList.getProductList.Find(x => x.Name == args.Value.ToString());
            buffComponent.Quantity--;
            var name = buffComponent.Name;
            var component = productList.newProductList.Find(x => x.Name == name);
            if (component == null)
            {
                productList.newProductList.Add(new Product(buffComponent.Name, buffComponent.TypeProduct, buffComponent.Manufacturer, buffComponent.Article, 1));
            }
        }

        private void AddNewTask()
        {
            if (_nameTask != null)
            {
                MongoDataBase.AddTaskToDB(new TaskList(_nameTask));
                _nameTask = string.Empty;
                Cancel();
                _addTaskComplete = true;
                OnInitialized();
            }
        }

        private void MinusClick(int article)
        {
            var product = productList.getProductList.Find(x => x.Article == article);
            var newProduct = productList.newProductList.Find(x => x.Article == article);
            if (newProduct.Quantity > 0)
            {
                newProduct.Quantity--;
                product.Quantity++;
            }
            _countEditActive = true;
            _nameComponent = product.Name;
            _quantity = product.Quantity;
            OnInitialized();
        }

        private void PlusClick(int article)
        {
            var product = productList.getProductList.Find(x => x.Article == article);
            var newProduct = productList.newProductList.Find(x => x.Article == article);
            if (product.Quantity > 0)
            {
                newProduct.Quantity++;
                product.Quantity--;
            }
            _countEditActive = true;
            _nameComponent = product.Name;
            _quantity = product.Quantity;
            OnInitialized();
        }

        private void DeleteComponent(int article)
        {
            var buffComponent = productList.newProductList.Find(x => x.Article == article);
            productList.newProductList.Remove(buffComponent);
        }

        private void DeleteTask(string name)
        {
            var buffComponent = taskList.newTaskList.Find(x => x.NameTask == name);
            taskList.newTaskList.Remove(buffComponent);
        }
    }
}