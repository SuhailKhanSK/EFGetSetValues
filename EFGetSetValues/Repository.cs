using EFGetSetValues.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetSetValues
{
    public class Repository
    {
        public void Save(Country country)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var existingCon = context.Countries
                    .Include(c => c.States)
                    .FirstOrDefault(c => c.Id == country.Id);

                if (existingCon != null)
                {
                    context.Entry(existingCon).CurrentValues.SetValues(country);

                    // Update or Add States
                    foreach (var state in country.States)
                    {
                        var existingState = existingCon.States.FirstOrDefault(s => s.Id == state.Id);
                        if (existingState != null)
                        {
                            context.Entry(existingState).CurrentValues.SetValues(state);
                        }
                        else
                        {
                            existingCon.States.Add(state);
                        }
                    }

                    // Delete removed States
                    var removedStates = existingCon.States.Where(s => !country.States.Any(cs => cs.Id == s.Id)).ToList();
                    foreach (var removedState in removedStates)
                    {
                        existingCon.States.Remove(removedState);
                        context.Remove(removedState);
                    }
                }
                else
                {
                    context.Countries.Add(country);
                }

                int rows = context.SaveChanges();
            }
        }
    }
}
