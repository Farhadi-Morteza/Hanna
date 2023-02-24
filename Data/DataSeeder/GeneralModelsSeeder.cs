using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSeeder
{
    public static class GeneralModelsSeeder
    {
        
        public static void PublicSeed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            System.Guid Culture_faId = System.Guid.NewGuid();
            System.Guid Culture_enId = System.Guid.NewGuid();

            System.Guid Country_faId = System.Guid.NewGuid();
            System.Guid Country_enId = System.Guid.NewGuid();

            //modelBuilder.Entity<Models.ProductType>()
            //    .HasData(
            //        new {  Name = "اصلی" , Culture_faId},
            //        new {  Name = "فرعی" , Culture_faId}
            //        );

            modelBuilder.Entity<Models.ProductType>()
                .HasData(new System.Collections.Generic.List<Models.ProductType>()
                {
                    new(){Name = "اصلی"},
                    new(){Name = "فرعی"}
                    
                }
                );

            modelBuilder.Entity<Models.Culture>()
               .HasData(
                new Culture { Id = 1, Language = "Persian", Location = "Iran", LanguageTag = Data.Constant.CultureName.Persian_Iran_fa_IR },
                new Culture { Id = 2, Language = "English", Location = "United State", LanguageTag = Data.Constant.CultureName.English_UnitedStates_en_US }
                );

            //modelBuilder.Entity<Models.Country>()
            //    .HasData(
            //    new Models.Country { Id = Country_enId, Name = Constant.Countries.Iran, CultrueId = Culture_enId },
            //    new Models.Country { Id = Country_faId, Name = Constant.Countries.Iran_fa, CultrueId = Culture_faId }
            //    );



            #region Seed State
            //System.Guid CultrueId;
            //System.Guid CountryId;
            //System.Guid StateId;

            #endregion
            //foreach (var cultrueTage in typeof(Constant.CultureTage).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                     .Where(x => x.IsLiteral && !x.IsInitOnly)
            //                     .Select(x => x.GetValue(null)).Cast<string>())
            //{
            //    foreach (var cultrue in typeof(Constant.CultureName).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                         .Where(x => x.IsLiteral && !x.IsInitOnly && x.ToString().EndsWith(cultrueTage))
            //                         .Select(x => x.GetValue(null)).Cast<string>())
            //    {
            //        CultrueId = System.Guid.NewGuid();
            //        modelBuilder.Entity<Models.Culture>()
            //          .HasData(
            //             new Culture { Id = CultrueId, Language = "Persian", Location = "Iran", LanguageTag = cultrue.Trim(), IsActive = true }
            //             );

            //        foreach (var country in typeof(Constant.Countries).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                             .Where(x => x.IsLiteral && !x.IsInitOnly && x.ToString().EndsWith(cultrueTage))
            //                             .Select(x => x.GetValue(null)).Cast<string>())
            //        {
            //            CountryId = System.Guid.NewGuid();
            //            modelBuilder.Entity<Models.Country>()
            //                .HasData(new Country { Id = CountryId, Name = country.Trim(), CultrueId = CultrueId });

            //            foreach (var state in typeof(Constant.States).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                                 .Where(x => x.IsLiteral && !x.IsInitOnly && x.ToString().EndsWith(cultrueTage))
            //                                 .Select(x => x.GetValue(null)).Cast<string>())
            //            {
            //                StateId = System.Guid.NewGuid();
            //                modelBuilder.Entity<Models.State>()
            //                    .HasData(new State { Id = StateId, Name = state.Trim(), CultrueId = CultrueId , CountryId = CountryId});
            //            }
            //        }
            //    }

            //}


            //System.Guid CultureId;
            //foreach (var cultrue in typeof(Constant.CultureName).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                     .Where(x => x.IsLiteral && !x.IsInitOnly && x.ToString().EndsWith("en"))
            //                     .Select(x => x.GetValue(null)).Cast<string>())
            //{
            //    CultureId = System.Guid.NewGuid();
            //    if(cultrue.EndsWith("en"))
            //    {
            //        modelBuilder.Entity<Models.Culture>()
            //            .HasData(
            //            new Models.Culture { Id = CultureId, Language = "English", Location = "United State", LanguageTag = Constant.CultureName.English_UnitedStates, IsActive = true }
            //            );
            //    }

            //}


            #region Seed State and City
            //    System.Guid CountryId;
            //foreach (var Country in typeof(Constant.Countries_en).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                     .Where(x => x.IsLiteral && !x.IsInitOnly)
            //                     .Select(x => x.GetValue(null)).Cast<string>())
            //{
            //    CountryId = System.Guid.NewGuid();
            //    modelBuilder.Entity<Models.Country>()
            //        .HasData(new System.Collections.Generic.List<Models.Country>()
            //        {
            //            new(){Id = CountryId, Name = Country.Trim(), CultrueId = Culture_enId}
            //        });

            //}

            //System.Guid stateId;
            //foreach (var item in typeof(Constant.States).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            //                     .Where(x => x.IsLiteral && !x.IsInitOnly)
            //                     .Select(x => x.GetValue(null)).Cast<string>())
            //{
            //    stateId = System.Guid.NewGuid();
            //    modelBuilder.Entity<Models.State>()
            //        .HasData(new System.Collections.Generic.List<Models.State>()
            //        {

            //            new(){Id = stateId, Name = item.Trim(), CultrueId = Culture_enId, CountryId = Country_enId}
            //        });

            //    if (item == Constant.States.Tehran)
            //    {
            //        modelBuilder.Entity<Models.City>()
            //        .HasData(


            //        new Models.City { Id = System.Guid.NewGuid(), Name = "Varamin", CultrueId = Culture_enId, StateId = stateId },
            //        new Models.City { Id = System.Guid.NewGuid(), Name = "Shahriyar", CultrueId = Culture_enId, StateId = stateId },
            //        new Models.City { Id = System.Guid.NewGuid(), Name = "Quds", CultrueId = Culture_enId, StateId = stateId },
            //        new Models.City { Id = System.Guid.NewGuid(), Name = "EslamShahr", CultrueId = Culture_enId, StateId = stateId }

            //        );
            //    }
            //}
            #endregion

            //foreach (var item in typeof(Constant.PhoneNumberType).GetFields().Where(p => p.IsStatic && p.IsLiteral))
            //{
            //    modelBuilder.Entity<Models.PhoneNumberType>()
            //    .HasData(new System.Collections.Generic.List<Models.PhoneNumberType>()
            //    {
            //        new(){ Id = System.Guid.NewGuid(), Name =item.Name, CultrueId = Culture_enId}
            //    }
            //    );
            //}

            //foreach (var item in typeof(Constant.PhoneNumberType_fa).GetFields().Where(p => p.IsStatic && p.IsLiteral))
            //{
            //    modelBuilder.Entity<Models.PhoneNumberType>()
            //    .HasData(new System.Collections.Generic.List<Models.PhoneNumberType>()
            //    {
            //        new(){ Id = System.Guid.NewGuid(), Name =  item.Name, CultrueId = Culture_faId}
            //    }
            //    );
            //}
        }

        public static void CompanySeed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            foreach (var item in typeof(Constant.CompanyCategories)
                .GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                .Where(x => x.IsLiteral && !x.IsInitOnly)
                .Select(x => x.GetValue(null)).Cast<string>())
            {
                modelBuilder.Entity<Models.CompanyCategory>()
                    .HasData(new Models.CompanyCategory 
                    {
                        Id = System.Guid.NewGuid(),
                        Name = item.Trim(),
                    });
            }

            foreach (var item in typeof(Constant.CompanyType)
                .GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                .Where(x => x.IsLiteral && !x.IsInitOnly)
                .Select(x => x.GetValue(null)).Cast<string>())
            {
                modelBuilder.Entity<Models.CompanyType>()
                    .HasData(new Models.CompanyType
                    {
                        Id = System.Guid.NewGuid(),
                        Name = item.Trim(),
                    });
            }


        }

        public static void EmployeesSeed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            
            Guid guid1 = Guid.Parse("d8a4c858-7c01-497e-9658-1aa2d832c728");
            Guid guid2 = Guid.Parse("7a4f16a2-1352-41fb-8b2c-09d9ec07c916");
            Guid guid3 = Guid.Parse("fce3ea9f-ef52-47c9-a06e-2946f2a955cb");
            Guid guid4 = Guid.Parse("f786edaa-921f-413c-9953-7129f2bbe4ea");
            Guid guid5 = Guid.Parse("b91327b3-79b6-40c5-9c52-3e6f6dbacb17");
            Guid guid6 = Guid.Parse("d6e0781e-f92d-4ada-bf86-4943fbf3f42c");

            modelBuilder.Entity<Models.Employee>()
                .HasData(new List<Models.Employee>()
                {
                    new() {Id = guid1, Name = "Charles Montgomery Burns", Title = "Owner"},
                    new() {Id = guid2, Name = "Waylon Smithers, Jr.", Title = "Assistant", ManagerId = guid1},
                    new() {Id = guid3, Name = "Lenny Leonard", Title = "Technical Supervisor", ManagerId = guid2},
                    new() {Id = guid4, Name = "Carl Carlson", Title = "Safety Operations Supervisor", ManagerId = guid2},
                    new() {Id = guid5, Name = "Inanimate Carbon Rod", Title = "Rod", ManagerId = guid4},
                    new() {Id = guid6, Name = "Homer Simpson", Title = "Safety Inspector", ManagerId = guid5}
                });
        }
    }
}
