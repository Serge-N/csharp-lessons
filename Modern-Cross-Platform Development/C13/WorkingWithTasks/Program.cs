﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;
namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();

            // SingleThread();
            MultiThread();

            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }

        static void SingleThread()
        {
            WriteLine("Running methods synchronously on one thread.");
            MethodA();
            MethodB();
            MethodC();
        }

        static void MultiThread()
        {
            WriteLine("Running methods asynchronously on multiple threads.");
            Task taskA = new Task(MethodA);
            taskA.Start();

            Task taskB = Task.Factory.StartNew(MethodB);

            Task taskC = Task.Run(new Action(MethodC));
        }

        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work
            WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate two seconds of work
            WriteLine("Finished Method B.");
        }

        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate one second of work
            WriteLine("Finished Method C.");
        }
    }
}
