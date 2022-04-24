#nullable disable

using App.Models.DatabaseModels;

namespace App.Data;

public static class AppDbContextExtension
{
    public static List<Vehicule.AvailableCategory> Categories;
    public static List<Vehicule> Vehicules;

    public static void Seed(this IRepository repo)
    {
        Categories = new List<Vehicule.AvailableCategory>
        {
            new Vehicule.AvailableCategory
            {
                Id = 1,
                Name = "Super Car",
                Description = "A supercar is a loosely defined description of street-legal, high-performance sports cars. Since the 2000s or 2010s, the term hypercar has come into use for the highest performing supercars. Supercars commonly serve as the flagship model within a vehicle manufacturer's line-up of sports cars and typically feature various performance-related technology derived from motorsports.",
                Color = "#6a00ff",
                Image = "https://i.gaw.to/content/photos/27/77/277780_2017_Lamborghini_Aventador.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 2,
                Name = "Italian Classic",
                Description = "An Italian classic car is an older car, typically 25 years or older, though definitions vary",
                Color = "#0e300b",
                Image = "https://pbs.twimg.com/media/ELnN8cxXUAEMLBO.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 3,
                Name = "Muscle Car",
                Description = "Muscle car is a description according to Merriam-Webster Dictionary that came to use in 1966 for 'a group of American-made two-door sports coupes with powerful gas powered engines designed for high-performance driving.'",
                Color = "#000045",
                Image = "https://cdn.catawiki.net/assets/marketing/uploads-files/54537-3540681cf7426c0b82a893e00fbc92db0fa0b1f9-original.png"
            },

            new Vehicule.AvailableCategory
            {
                Id = 4,
                Name = "American Legend",
                Description = "An American Legend car is a legendary & famous car.",
                Color = "#919191",
                Image = "https://thechicicon.com/wp-content/uploads/2020/09/24002-n-1160x580.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 5,
                Name = "Hyper Car",
                Description = "A more recent term for high-performance sportscars is 'hypercar', which is sometimes used to describe the highest performing supercars. As per supercars, there is no set definition for what constitutes a hypercar. An attempt to define these is 'a limited-production, top-of-the-line supercar with a price of around or more than US$1 million.'",
                Color = "#ffea00",
                Image = "https://www.breezcar.com/img-c/pageimg/3407_W750.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 6,
                Name = "Japan Race Car",
                Description = "A Japanese Race Car is a sports car is a car created by a japanese constructor, designed with an emphasis on dynamic performance, such as handling, acceleration, top speed, or thrill of driving.",
                Color = "#c45c5c",
                Image = "https://www.carpixel.net/w/4523667dd89e5f89c7e08ef62a5efb3f/subaru-wrx-sti-race-car-car-wallpaper-107412.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 7,
                Name = "Sport Car",
                Description = "A sports car is a car designed with an emphasis on dynamic performance, such as handling, acceleration, top speed, or thrill of driving. Sports cars originated in Europe in the early 1900s and are currently produced by many manufacturers around the world.",
                Color = "#0055ff",
                Image = "https://upload.wikimedia.org/wikipedia/commons/2/2c/1996_Porsche_911_993_GT2_-_Flickr_-_The_Car_Spy_%284%29.jpg"
            },

            new Vehicule.AvailableCategory
            {
                Id = 8,
                Name = "German Classic",
                Description = "A German classic car is an older car, typically 25 years or older, though definitions vary",
                Color = "#3b0000",
                Image = "https://upload.wikimedia.org/wikipedia/commons/9/90/MB_190_SL_am_2006-07-16_%28ret_kl%29.JPG"
            },

            new Vehicule.AvailableCategory
            {
                Id = 9,
                Name = "High Performance Sport Car",
                Description = "A High Performance Sport Car is a Sport car with better stats.",
                Color = "#00d5ff",
                Image = "https://autofans.be/sites/default/files/styles/artikel_intro/public/media/2021/BMW/anderefotos/bmw-m4-gt3-2021_01.jpg?itok=uqbX747n"
            },
        };

        Vehicules = new List<Vehicule>
        {
            new Vehicule
            {
                Id = 1,
                Brand = "Ferrari",
                Model = "F40",
                BuildDate = new DateTime(1987, 01, 01),
                HorsePower = 478,
                PowerLevel = 7,
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/F40_Ferrari_20090509.jpg/280px-F40_Ferrari_20090509.jpg",
                Categories = Categories.FindAll(x => x.Name == "Super Car" && x.Name=="Italian Classic")
            },

            new Vehicule
            {
                Id = 2,
                Brand = "Lamborghini",
                Model = "Huracan",
                BuildDate = new DateTime(2014, 01, 01),
                HorsePower = 650,
                PowerLevel = 7,
                Image = "https://upload.wikimedia.org/wikipedia/commons/3/31/2014-03-04_Geneva_Motor_Show_1377.JPG",
                Categories = Categories.FindAll(x => x.Name == "Super Car")
            },

            new Vehicule
            {
                Id = 3,
                Brand = "Ford",
                Model = "Mustang'67",
                BuildDate = new DateTime(1967, 01, 01),
                HorsePower = 320,
                PowerLevel = 3,
                Image = "https://www.mustangspecs.com/wp-content/uploads/2019/10/1967-Mustang-In-Depth-Guide.jpg",
                Categories = Categories.FindAll(x => x.Name == "Muscle Car" && x.Name == "American Legend")
            },

            new Vehicule
            {
                Id = 4,
                Brand = "Dodge",
                Model = "Charger R/T",
                BuildDate = new DateTime(2021, 01, 01),
                HorsePower = 370,
                PowerLevel = 5,
                Image = "https://overtake-images.sfo2.digitaloceanspaces.com/2021/Dodge/Charger/DG021_030CHbfqds5i7seuipr3q45r5ds1hp3.jpg",
                Categories = Categories.FindAll(x => x.Name == "Muscle Car")
            },

            new Vehicule
            {
                Id = 5,
                Brand = "Pagani",
                Model = "Huayra R",
                BuildDate = new DateTime(2018, 01, 01),
                HorsePower = 850,
                PowerLevel = 9,
                Image = "https://www.ccarprice.com/products/Pagani_Huayra_R_CouPe_2022.jpg",
                Categories = Categories.FindAll(x => x.Name == "Hyper Car")
            },

            new Vehicule
            {
                Id = 6,
                Brand = "Bugatti",
                Model = "Chiron",
                BuildDate = new DateTime(2019, 01, 01),
                HorsePower = 1500,
                PowerLevel = 10,
                Image = "https://upload.wikimedia.org/wikipedia/commons/6/63/FoS20162016_0624_132444AA_%2827785299372%29.jpg",
                Categories = Categories.FindAll(x => x.Name == "Hyper Car")
            },

            new Vehicule
            {
                Id = 7,
                Brand = "Toyota",
                Model = "Supra Yakuza Edition",
                BuildDate = new DateTime(1995, 01, 01),
                HorsePower = 335,
                PowerLevel = 7,
                Image = "https://photos.tf1.fr/1200/720/toyota-supra-paul-walker-fast-furious-11-44677f-0@1x.jpg",
                Categories = Categories.FindAll(x => x.Name == "Japan Race Car")
            },

            new Vehicule
            {
                Id = 8,
                Brand = "Honda",
                Model = "S2000 Racing",
                BuildDate = new DateTime(2009, 01, 01),
                HorsePower = 240,
                PowerLevel = 6,
                Image = "https://racemarket.net/oc-content/uploads/25/10442.jpg",
                Categories = Categories.FindAll(x => x.Name == "Japan Race Car" && x.Name == "Race Car")
            },

            new Vehicule
            {
                Id = 9,
                Brand = "BMW",
                Model = "E30 ‘91",
                BuildDate = new DateTime(1991, 01, 01),
                HorsePower = 238,
                PowerLevel = 6,
                Image = "https://www.automobile-sportive.com/guide/bmw/325ise30/bmw-325is-e30.jpg",
                Categories = Categories.FindAll(x => x.Name == "German Classic" && x.Name == "Race Car")
            },

            new Vehicule
            {
                Id = 10,
                Brand = "Porsche",
                Model = "911 GT3",
                BuildDate = new DateTime(2007, 01, 01),
                HorsePower = 415,
                PowerLevel = 7,
                Image = "https://s1.cdn.autoevolution.com/images/gallery/PORSCHE-911-GT3--997--1192_30.jpg",
                Categories = Categories.FindAll(x => x.Name == "German Classic" && x.Name == "High Performance Race Car")
            },
        };

        try
        {
            foreach (var category in Categories)
                repo.Add(category);

            foreach (var vehicule in Vehicules)
                repo.Add(vehicule);

            repo.Update<Vehicule.AvailableCategory>();
            repo.Update<Vehicule>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}