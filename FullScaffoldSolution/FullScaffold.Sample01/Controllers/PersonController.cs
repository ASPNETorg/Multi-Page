using FullScaffold.Samlple01.Models.Frameworks.Contracts;
using FullScaffold.Sample01.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace FullScaffold.Sample01.Controllers
{
    public class PersonController : Controller
    {
         private readonly IPersonRepository _personRepository;

        #region [- Ctor -]
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            return View(await _personRepository.Select());
        }
        #endregion

        #region [- Details -]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _personRepository.Select(id));
        }
        #endregion

        #region [- Create() -]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- Create Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstname,Lastname")] Person person)
        {
            if (ModelState.IsValid) {   
                await _personRepository.Insert(person);
                return RedirectToAction(nameof(Index));
            }
             return View(person);
        }
        #endregion

        #region [- Edit -]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }
        #endregion

        #region [- Edit Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Firstname,Lastname")] Person person)
        {
            if (ModelState.IsValid) {   
            await _personRepository.Update(person);
            return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        #endregion

        #region [- Delete -]
        public async Task<IActionResult> Delete(Guid? id)
        {
             if (id == null)
             {
                return NotFound();
             }
            Person p = await _personRepository.Select(id);
            return View(p);
        }
        #endregion

        #region [- Delete Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Person person)
        {
            await _personRepository.Delete(person);
            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
