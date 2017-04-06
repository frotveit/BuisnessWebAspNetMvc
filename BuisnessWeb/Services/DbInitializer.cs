

using BuisnessWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessWeb.Services
{
    public struct ShopCategoryConstants
    {
        public const string Uniforms = "Uniforms";
        public const string CompanyArticles = "CompanyArticles";
        public const string HomeOffice = "HomeOffice";
    }

    public class DbInitializer
    {
        public static void Seed( IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Employees.Any())
            {
                context.AddRange
                (
                    new Employee
                    {
                        Name = "John Doe",
                        Phone = 12345678,
                        PaymentInformation = new PaymentInformation {PaymentModel= PaymentModel.Fixed }
                    },
                    new Employee { Name = "Jane Doe", Phone = 12345678,
                        PaymentInformation = new PaymentInformation { PaymentModel = PaymentModel.Fixed } },
                    new Employee { Name = "Albert Einstein", Phone = 12345678,
                        PaymentInformation = new PaymentInformation { PaymentModel = PaymentModel.Fixed }
                    },
                    new Employee { Name = "Susie Smith", Phone = 12345678,
                        PaymentInformation = new PaymentInformation { PaymentModel = PaymentModel.Fixed }
                    },
                    new Employee { Name = "Linn Light", Phone = 12345678,
                        PaymentInformation = new PaymentInformation { PaymentModel = PaymentModel.Fixed }
                    }
                );                
            }

            if (!context.HourRegistration.Any())
            {
                context.AddRange
                (
                    new HourRegistration { EmployeeId = 2, Date = DateTime.Today, Hours = 1 },
                    new HourRegistration { EmployeeId = 2, Date = DateTime.Today.AddDays(-1), Hours = 1 }
                );                
            }

            if (!context.ShopCategories.Any())
            {
                context.ShopCategories.AddRange(ShopCategories.Select(c => c.Value));
            }

            if (!context.ShopItems.Any())
            {
                context.AddRange
                (
                    new ShopItem { Name = "Jacket", Price = 1200, ShortDescription = "Uniform jacket", LongDescription = "", ShopCategory = ShopCategories[ShopCategoryConstants.Uniforms], ImageUrl = "", InStock = true, IsItemOfTheWeek = true },
                    new ShopItem { Name = "Cap", Price = 200, ShortDescription = "Uniform cap", LongDescription = "", ShopCategory = ShopCategories[ShopCategoryConstants.Uniforms], ImageUrl = "", InStock = true, IsItemOfTheWeek = true },
                    new ShopItem { Name = "Cup", Price = 1200, ShortDescription = "Cup with logo", LongDescription = "", ShopCategory = ShopCategories[ShopCategoryConstants.CompanyArticles], ImageUrl = "", InStock = true },
                    new ShopItem { Name = "Computer", Price = 300, ShortDescription = "Home computer", LongDescription = "", ShopCategory = ShopCategories[ShopCategoryConstants.HomeOffice], ImageUrl = "", InStock = true },
                    new ShopItem { Name = "Screen", Price = 100, ShortDescription = "Computer screen", LongDescription = "", ShopCategory = ShopCategories[ShopCategoryConstants.HomeOffice], ImageUrl = "", InStock = true }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, ShopCategory> shopCategories;
        public static Dictionary<string, ShopCategory> ShopCategories
        {
            get
            {
                if (shopCategories == null)
                {
                    var genresList = new ShopCategory[]
                    {
                        new ShopCategory { ShopCategoryName = ShopCategoryConstants.Uniforms },
                        new ShopCategory { ShopCategoryName = ShopCategoryConstants.CompanyArticles },
                        new ShopCategory { ShopCategoryName = ShopCategoryConstants.HomeOffice }
                    };

                    shopCategories = new Dictionary<string, ShopCategory>();

                    foreach (ShopCategory genre in genresList)
                    {
                        shopCategories.Add(genre.ShopCategoryName, genre);
                    }
                }

                return shopCategories;
            }
        }
    }
}
