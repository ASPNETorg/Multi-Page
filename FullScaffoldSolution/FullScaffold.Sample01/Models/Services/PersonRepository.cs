using FullScaffold.Samlple01.Models.Frameworks.Contracts;
using FullScaffold.Sample01.Models;
using FullScaffold.Sample01.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

using System;

namespace S08.Fullscaffold.samlple02.Models.Services
{
    public class PersonRepository : IPersonRepository
    {
         #region [- Ctor -]
        private readonly ProjectDbContext _dbContext;
        public PersonRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

        #region [- Select() -]
        public async Task<List<Person>> Select()
        {
            using (_dbContext)
            {
                try
                {
                    var persons = await _dbContext.Person.ToListAsync();
                    return persons;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_dbContext.Person != null) _dbContext.Dispose();
                }
            }
        }
		#endregion

		#region [- SelectById() -]
		public async Task<Person> Select(Guid? id)
		{
			using (_dbContext)
			{
				try
				{
					var person = await _dbContext.Person
						.FirstOrDefaultAsync(m => m.Id == id);
					return person;
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					if (_dbContext.Person != null) _dbContext.Dispose();
				}
			}
		}
		#endregion

		#region [- Insert() -]
		public async Task Insert(Person person)
        {
            using (_dbContext)
            {
                try
                {
                    var p = new Person()
                    {
                        Id = Guid.NewGuid(),
                        Firstname = person.Firstname,
                        Lastname = person.Lastname,
                    };

                    _dbContext.Person.Add(p);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_dbContext.Person != null) _dbContext.Dispose();
                }
            }
        }
        #endregion

        #region [- Update() -]
        public async Task Update(Person person)
        {
            using (_dbContext)
            {
                try
                {
                    var p = _dbContext.Update(person);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                finally
                {
                    if (_dbContext.Person != null) _dbContext.Dispose();
                }
            }

        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(Person person)
        {
            try
            {
                var p = _dbContext.Remove(person);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            finally
            {
                if (_dbContext.Person != null) _dbContext.Dispose();
            }

        }
        #endregion

    }
}

