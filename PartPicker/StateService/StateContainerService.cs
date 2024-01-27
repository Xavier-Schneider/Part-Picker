using PartPicker.Models;
using System.Diagnostics;

namespace PartPicker.StateService
{
    public class StateContainerService //added test comment
    {
        public VehicleFilter filter { get; private set; }
        public Part genericCar { get; private set; }
        public Cart cart { get; private set; }

        public StateContainerService()
        {
            AddCarModels();
            PopulateParts();
            InitializeCart();
        }

        void AddCarModels()
        {
            List<Vehicle> vehicles= new List<Vehicle>();
            vehicles.Add(new Vehicle("Acura", "Integra", "1986", "PL", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Acura", "TLX", "2014", "VW", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Acura", "CDX", "2020", "TT", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Aston Martin", "DB5", "1963", "RALLY", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Aston Martin", "DB5", "1963", "MI6", "Assets/AstonMartinDB5.jpg"));
            vehicles.Add(new Vehicle("BMW", "F40", "2019", "GG", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("BMW", "F40", "2004", "LTX", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("BMW", "F40", "2004", "HH", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Chevrolet", "Silverado", "2010", "TV", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Chevrolet", "Spark", "2011", "XL", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Ford", "F150", "1990", "TWD", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Ford", "F150 Lightning", "2022", "LT", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("GMC", "Acadia", "2017", "AWD", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("GMC", "Sierra", "1988", "DTL", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Honda", "Civic", "2015", "XL", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Nissan", "Leaf", "2018", "PREM", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Tesla", "Cybertruck", "2024", "STD", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Tesla", "Model3", "2020", "STD", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Tesla", "Model3", "2019", "EXT", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Toyota", "Rav4", "2019", "AWD", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Toyota", "Rav4", "2019", "LT", "Assets/Sample car.jpg"));
            vehicles.Add(new Vehicle("Toyota", "Sequoia", "2013", "MOBY", "Assets/Sample car.jpg"));

            filter = new VehicleFilter(vehicles);
        }

        void PopulateParts()
        {
            HashSet<Part> genericCarSubParts = new HashSet<Part>();
            HashSet<Part> tireSubParts = new HashSet<Part>();
            HashSet<Part> breakSubParts = new HashSet<Part>();
            HashSet<Part> mirrorSubParts = new HashSet<Part>();
            HashSet<Part> drivetrainSubParts = new HashSet<Part>();
            HashSet<Part> coverSubParts = new HashSet<Part>();
            HashSet<Part> driveshaftSubParts = new HashSet<Part>();
            genericCar = new Part("Aston Martin DB5 1963 MI6", "Assets/Car isolated.gltf", "Assets/Car expanded.gltf", genericCarSubParts, null);
            Part wheels = new Part("Wheels", "Assets/Wheels isolated.gltf", "Assets/Wheels isolated.gltf", tireSubParts, genericCar);
            Part rightFrontWheel = new Part("Right front wheel", "Assets/Wheel isolated.gltf", "Assets/Wheel isolated.gltf", null, wheels, 875.99);
            Part leftFrontWheel = new Part("Left front wheel", "Assets/Wheel isolated.gltf", "Assets/Wheel isolated.gltf", null, wheels, 875.99);
            Part rightRearWheel = new Part("Right rear wheel", "Assets/Wheel isolated.gltf", "Assets/Wheel isolated.gltf", null, wheels, 875.99);
            Part leftRearWheel = new Part("Left rear wheel", "Assets/Wheel isolated.gltf", "Assets/Wheel isolated.gltf", null, wheels, 875.99);
            genericCarSubParts.Add(wheels);
            tireSubParts.Add(rightFrontWheel);
            tireSubParts.Add(leftFrontWheel);
            tireSubParts.Add(rightRearWheel);
            tireSubParts.Add(leftRearWheel);
            Part breaks = new Part("Brakes", "Assets/Brakes isolated.gltf", "Assets/Brakes isolated.gltf", breakSubParts, genericCar);
            Part rightFrontBreak = new Part("Right front brake", "Assets/Brake front right isolated.gltf", "Assets/Brake front right isolated.gltf", null, breaks, 217.55);
            Part leftFrontBreak = new Part("Left front brake", "Assets/Brake front left isolated.gltf", "Assets/Brake front left isolated.gltf", null, breaks, 217.55);
            Part rightRearBreak = new Part("Right rear brake", "Assets/Brake back right isolated.gltf", "Assets/Brake back right isolated.gltf", null, breaks, 250.72);
            Part leftRearBreak = new Part("Left rear brake", "Assets/Brake back left isolated.gltf", "Assets/Brake back left isolated.gltf", null, breaks, 250.72);
            genericCarSubParts.Add(breaks);
            breakSubParts.Add(rightFrontBreak);
            breakSubParts.Add(leftFrontBreak);
            breakSubParts.Add(rightRearBreak);
            breakSubParts.Add(leftRearBreak);
            Part mirrors = new Part("Mirrors", "Assets/Mirrors isolated.gltf", "Assets/Mirrors isolated.gltf", mirrorSubParts, genericCar);
            Part rightMirror = new Part("Right mirror", "Assets/Mirror right isolated.gltf", "Assets/Mirror right isolated.gltf", null, mirrors, 153.00);
            Part leftMirror = new Part("Left mirror", "Assets/Mirror left isolated.gltf", "Assets/Mirror left isolated.gltf", null, mirrors, 153.00);
            genericCarSubParts.Add(mirrors);
            mirrorSubParts.Add(rightMirror);
            mirrorSubParts.Add(leftMirror);
            Part drivetrain = new Part("Drive train", "Assets/Drivetrain isolated.gltf", "Assets/Drivetrain expanded.gltf", drivetrainSubParts, genericCar, 2376.00);
            Part housing = new Part("Differential housing", "Assets/Differential housing isolated.gltf", "Assets/Differential housing isolated.gltf", null, drivetrain, 570.39);
            Part leftaxel = new Part("Left axel", "Assets/Axel left isolated.gltf", "Assets/Axel left isolated.gltf", null, drivetrain, 205.00);
            Part rightaxel = new Part("Right axel", "Assets/Axel right isolated.gltf", "Assets/Axel right isolated.gltf", null, drivetrain, 205.00);
            Part cover = new Part("Differential cover", "Assets/Differential cover isolated.gltf", "Assets/Differential cover expanded.gltf", coverSubParts, drivetrain, 99.99);
            Part coverPlate = new Part("Differential cover plate", "Assets/Differential cover plate isolated.gltf", "Assets/Differential cover plate isolated.gltf", null, cover, 79.99);
            Part bolts = new Part("Bolts", "Assets/Differential bolts isolated.gltf", "Assets/Differential bolts isolated.gltf", null, cover, 22.15);
            coverSubParts.Add(coverPlate);
            coverSubParts.Add(bolts);
            Part driveshaft = new Part("Drive shaft", "Assets/Driveshaft isolated.gltf", "Assets/Driveshaft expanded.gltf", driveshaftSubParts, drivetrain, 1725.12);
            Part frontBearing = new Part("Front bearing", "Assets/Front bearing isolated.gltf", "Front bearing isolated.gltf", null, driveshaft, 43.07);
            Part rearShaft = new Part("Rear shaft", "Assets/Rear driveshaft isolated.gltf", "Assets/Rear driveshaft isolated.gltf", null, driveshaft, 999.99);
            Part frontShaft = new Part("Front shaft", "Assets/Front driveshaft isolated.gltf", "Assets/Front driveshaft isolated.gltf", null, driveshaft, 999.99);
            Part spider = new Part("Spider", "Assets/Spider isolated.gltf", "Assets/Spider isolated.gltf", null, driveshaft, 0.07);
            driveshaftSubParts.Add(frontBearing);
            driveshaftSubParts.Add(rearShaft);
            driveshaftSubParts.Add(frontShaft);
            driveshaftSubParts.Add(spider);

            genericCarSubParts.Add(drivetrain);
            drivetrainSubParts.Add(housing);
            drivetrainSubParts.Add(leftaxel);
            drivetrainSubParts.Add(rightaxel);
            drivetrainSubParts.Add(cover);
            drivetrainSubParts.Add(driveshaft);
        }

        void InitializeCart()
        {
            cart = new Cart();
        }
    }
}
