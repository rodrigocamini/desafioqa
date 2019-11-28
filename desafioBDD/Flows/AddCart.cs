using RodrigoDesafioCit.Helpers;
using RodrigoDesafioCit.Pages;
using RodrigoDesafioCit.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Flows
{
    public class MyTaskFlows
    {
        MyTasksPage myTaskPage;

        public MyTaskFlows()
        {
            myTaskPage = new MyTasksPage();
        }

        public string AddNewTask()
        {
            string newTask = "Task - " + BaseDriver.ReturnStringWithRandomCharacters(2);
            myTaskPage.ClickMyTask();
            myTaskPage.FillNameTask(newTask);
            myTaskPage.ClickAddTask();
            return newTask;
        }

    }
}
