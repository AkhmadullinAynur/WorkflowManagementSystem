using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    //public partial class Planner
    //{
    //    List<Project> projects = new List<Project>();
    //    List<TaskList> taskLists = MongoDataBase.GetTaskList();
    //    List<Product> productList = MongoDataBase.GetProductList();
    //    List<TaskList> newTaskList = new List<TaskList>();
    //    List<Product> newProductList = new List<Product>();
    //    List<TaskList> showTaskList = new List<TaskList>();
    //    List<Product> showProdyctList = new List<Product>();
    //    List<Product> product;

    //    private int _numberProject;
    //    private string _nameProject;
    //    private int _count;
    //    private int _editCount;
    //    private int _buffer;
    //    private string _nameComponent;
    //    private int _quantity;
    //    private int _article;

    //    private string _nameTask;

    //    public string Value { get; set; }

    //    private bool _isEditActiv;
    //    private bool _isEditActivPanel;
    //    private bool _isNewProjectActive;
    //    private bool _isNewProject;
    //    private bool _isRegComplete;
    //    private bool _isEditComplete;
    //    private bool _countEditActive;
    //    private bool _addTaskActive;
    //    private bool _addTaskComplete;

    //    private void IsNewproject()
    //    {
    //        Refrash();
    //        MessageFalse();
    //        projects = new List<Project>();
    //        _numberProject = 99;
    //        foreach (var item in project.projects)
    //        {
    //            _numberProject = item.NumberProject;
    //        }
    //        int number = _numberProject;
    //        for (int i = 100; i <= number + 1; i++)
    //        {
    //            _numberProject = i;
    //        }
    //        _isNewProject = !_isNewProject;
    //        _isRegComplete = false;
    //        _isEditActiv = false;
    //        _isEditComplete = false;
    //        _isNewProjectActive = !_isNewProjectActive;
    //    }

    //    private void IsEditActiv(int number)
    //    {
    //        Refrash();
    //        MessageFalse();
    //        projects = MongoDataBase.FindProject(number);
    //        _isEditActiv = true;
    //        _isEditActivPanel = true;
    //        _isNewProjectActive = true;
    //        _isNewProject = false;
    //        _countEditActive = false;
    //        _addTaskActive = false;
    //        OnInitialized();
    //    }
    //    private void AddTaskActive()
    //    {
    //        MessageFalse();
    //        _addTaskActive = !_addTaskActive;
    //        _isNewProjectActive = true;
    //    }
    //    private void countEditActive(int article)
    //    {
    //        MessageFalse();
    //        _isEditActivPanel = false;
    //        _countEditActive = true;
    //        _isNewProjectActive = true;
    //        product = MongoDataBase.FindProduct(article);
    //        if (_isNewProject)
    //        {
    //            foreach (var item in product)
    //            {
    //                _nameComponent = @item.Name;
    //                _quantity = @item.Quantity;
    //                _article = item.Article;
    //            }
    //            foreach (var item in newProductList)
    //            {
    //                _editCount = item.Count;
    //                _count = item.Count;
    //            }
    //        }
    //        else
    //        {
    //            var project = MongoDataBase.GetComponentList(_numberProject);
    //            var count = project.Find(x => x.Article == article);
    //            _editCount = count.Count;
    //            _count = count.Count;
    //            foreach (var item in product)
    //            {
    //                _nameComponent = @item.Name;
    //                _quantity = @item.Quantity;
    //                _article = item.Article;
    //            }
    //        }
    //        _buffer = _quantity;
    //    }

    //    private void FinishEdit()
    //    {
    //        _isEditComplete = !_isEditComplete;
    //        newProductList = MongoDataBase.GetComponentList(_numberProject);
    //        newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //        MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //        OnInitialized();
    //        Cancel();
    //    }

    //    private void Cancel()
    //    {
    //        Refrash();
    //        _isEditActiv = false;
    //        _isEditActivPanel = false;
    //        _isNewProjectActive = false;
    //        _isNewProject = false;
    //        _countEditActive = false;
    //        _addTaskActive = false;
    //    }
    //    private void MessageFalse()
    //    {
    //        _isRegComplete = false;
    //        _isEditComplete = false;
    //        _addTaskComplete = false;
    //    }
    //    private void CancelEditCount()
    //    {
    //        if (_isNewProject)
    //        {
    //            _isNewProject = true;
    //            _countEditActive = false;
    //        }
    //        else
    //        {
    //            _isEditActivPanel = true;
    //            _countEditActive = false;
    //        }
    //    }
    //    private void Refrash()
    //    {
    //        showTaskList = new List<TaskList>();
    //        newTaskList = new List<TaskList>();
    //        showProdyctList = new List<Product>();
    //        newProductList = new List<Product>();
    //        _nameProject = string.Empty;
    //    }

    //    protected override void OnInitialized()
    //    {
    //        project.projects = MongoDataBase.GetProjectList();
    //        taskLists = MongoDataBase.GetTaskList();
    //        productList = MongoDataBase.GetProductList();
    //        if (projects != null)
    //        {
    //            foreach (var item in projects)
    //            {
    //                _numberProject = item.NumberProject;
    //                _nameProject = item.NameProject;
    //            }
    //        }
    //    }

    //    private void AddProjectToDataBase()
    //    {
    //        if (_nameProject != null)
    //        {
    //            MongoDataBase.AddProjectToDB(new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            OnInitialized();
    //            newTaskList = new List<TaskList>();
    //            newProductList = new List<Product>();
    //            _isNewProject = !_isNewProject;
    //            _isRegComplete = !_isRegComplete;
    //            _isNewProjectActive = !_isNewProjectActive;
    //            Cancel();
    //        }
    //    }

    //    private void DeleteProject(int number)
    //    {
    //        MessageFalse();
    //        MongoDataBase.DeleteProject(number);
    //        Cancel();
    //        OnInitialized();
    //    }

    //    private void SelectionTask(ChangeEventArgs args)
    //    {
    //        if (_isNewProject)
    //        {
    //            var newBuffTasks = taskLists.Find(x => x.NameTask == args.Value.ToString());
    //            _nameTask = newBuffTasks.NameTask;
    //            newTaskList.Add(new TaskList(_nameTask));
    //        }
    //        else
    //        {
    //            newProductList = MongoDataBase.GetComponentList(_numberProject);
    //            newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //            var buffTasks = taskLists.Find(x => x.NameTask == args.Value.ToString());
    //            _nameTask = buffTasks.NameTask;
    //            var task = newTaskList.Find(x => x.NameTask == _nameTask);
    //            if (task == null)
    //            {
    //                newTaskList.Add(new TaskList(_nameTask));
    //                showTaskList.Add(new TaskList(_nameTask));
    //                MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            }
    //        }
    //        OnInitialized();
    //    }

    //    private void SelectionComponent(ChangeEventArgs args)
    //    {
    //        if (_isNewProject)
    //        {
    //            var newBuffComponent = productList.Find(x => x.Name == args.Value.ToString());
    //            newBuffComponent.Count = 1;
    //            newProductList.Add(newBuffComponent);
    //        }
    //        else
    //        {
    //            newProductList = MongoDataBase.GetComponentList(_numberProject);
    //            newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //            var buffComponent = productList.Find(x => x.Name == args.Value.ToString());
    //            buffComponent.Count = 1;
    //            var name = buffComponent.Name;
    //            var component = newProductList.Find(x => x.Name == name);
    //            if (component == null)
    //            {
    //                newProductList.Add(buffComponent);
    //                showProdyctList.Add(buffComponent);
    //                MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            }
    //        }
    //        OnInitialized();
    //    }

    //    private void AddNewTask()
    //    {
    //        if (_nameTask != null)
    //        {
    //            MongoDataBase.AddTaskToDB(new TaskList(_nameTask));
    //            _nameTask = string.Empty;
    //            Cancel();
    //            _addTaskComplete = true;
    //            OnInitialized();
    //        }
    //    }

    //    private void MinusClick()
    //    {
    //        if (_editCount > 0)
    //        {
    //            _editCount--;
    //            _buffer++;
    //        }
    //    }

    //    private void PlusClick()
    //    {
    //        if (_buffer > 0)
    //        {
    //            _editCount++;
    //            _buffer--;
    //        }

    //    }
    //    private void ReplaceCount()
    //    {
    //        if (_isNewProject)
    //        {
    //            if (newProductList.Exists(x => x.Article == _article))
    //            {
    //                var merch = newProductList.Find(x => x.Article == _article);
    //                merch.Count = _editCount;
    //            }
    //            CancelEditCount();
    //        }
    //        else
    //        {
    //            var project = MongoDataBase.FindProject(_numberProject);
    //            newProductList = MongoDataBase.GetComponentList(_numberProject);
    //            if (newProductList.Exists(x => x.Article == _article))
    //            {
    //                var merch = newProductList.Find(x => x.Article == _article);
    //                merch.Count = _editCount;
    //            }
    //            newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //            MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            CancelEditCount();
    //            IsEditActiv(_numberProject);
    //            OnInitialized();
    //        }
    //        if (_count > _editCount)
    //        {
    //            _quantity += _count - _editCount;
    //            Product.Replace(_article, _quantity);
    //        }
    //        else
    //        {
    //            _quantity -= _editCount - _count;
    //            Product.Replace(_article, _quantity);
    //        }
    //    }

    //    private void DeleteComponent(int article)
    //    {
    //        if (_isNewProject)
    //        {
    //            var buffComponent = newProductList.Find(x => x.Article == article);
    //            newProductList.Remove(buffComponent);
    //        }
    //        else
    //        {
    //            newProductList = MongoDataBase.GetComponentList(_numberProject);
    //            newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //            var buffComponent = newProductList.Find(x => x.Article == article);
    //            newProductList.Remove(buffComponent);
    //            showProdyctList.Remove(buffComponent);
    //            MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            _isEditActiv = false;
    //            IsEditActiv(_numberProject);
    //        }
    //    }

    //    private void DeleteTask(string name)
    //    {
    //        if (_isNewProject)
    //        {
    //            var buffComponent = newTaskList.Find(x => x.NameTask == name);
    //            newTaskList.Remove(buffComponent);
    //        }
    //        else
    //        {
    //            newProductList = MongoDataBase.GetComponentList(_numberProject);
    //            newTaskList = MongoDataBase.GetProjectTaskList(_numberProject);
    //            var buffComponent = newTaskList.Find(x => x.NameTask == name);
    //            newTaskList.Remove(buffComponent);
    //            showTaskList.Remove(buffComponent);
    //            MongoDataBase.ReplaceProject(_numberProject, new Project(_numberProject, _nameProject, newTaskList, newProductList));
    //            _isEditActiv = false;
    //            IsEditActiv(_numberProject);
    //        }
    //    }
    //}
}
