using Microsoft.AspNetCore.Mvc;
using MVCCoreTutorial.Models.Domain;
using System;

namespace MVCCoreTutorial.Controllers;

public class PersonController : Controller
{
    private readonly DatabaseContext? _context;
    public PersonController(DatabaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {

        ViewBag.greeting = "Hello World this is from view bag method";
        ViewData["greeting2"] = "this is from ViewData";
        TempData["greeting3"] = "this is from tempdata message";

        return View();
    }

    [HttpGet]
    public IActionResult AddPerson()
    {

      
        return View();

    }


    [HttpPost]
    public IActionResult AddPerson(Person person)
    {
        if (!ModelState.IsValid)
        {

            return View();
        }

        try
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            TempData["msg"] = "Data Successfully Added!";
            return RedirectToAction("DisplayPerson");

        }
        catch(Exception ex)
        {
            TempData["msg"] = "Data Count not Added!";
            return View();
            throw;
        }

       
       

    }

    public IActionResult DisplayPerson()
    {

        var persons = _context.Person.ToList();

        return View(persons);

    }

    public IActionResult EditPerson(int id)
    {
        var person = _context.Person.Find(id);

        return View(person);

    }
    [HttpPost]
    public IActionResult EditPerson(Person person)
    {
        if (!ModelState.IsValid)
        {

            return View();
        }

        try
        {
            _context.Person.Update(person);
            _context.SaveChanges();
           
            return RedirectToAction("DisplayPerson");


        }
        catch (Exception ex)
        {
            TempData["msg"] = "Data Count not Updated!";
            return View();
            throw;
        }




    }

    public IActionResult DeletePerson(int id)
    {
        try
        {

            var person = _context.Person.Find(id);
            if (person != null)
            {
                _context.Person.Remove(person);
                _context.SaveChanges(); 

            }
              

        }
        catch(Exception ex)
        {


       

        }

        return RedirectToAction("DisplayPerson");

    }


}
