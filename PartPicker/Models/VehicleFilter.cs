namespace PartPicker.Models
{
    public class VehicleFilter
    {
        private List<Vehicle> vehicleList;
        public List<Vehicle> filteredList;

        private String makeFilter;
        private String modelFilter;
        private String yearFilter;
        private String trimFilter;

        public List<String> makes;
        public List<String> models;
        public List<String> years;
        public List<String> trims;

        public VehicleFilter(List<Vehicle> vehicleList)
        {
            this.vehicleList = new List<Vehicle>(vehicleList);
            clear();
        }

        public String make
        {
            get { return makeFilter; }
            set 
            { 
                makeFilter = value;
                modelFilter = "";
                yearFilter = "";
                years = new List<String>();
                trimFilter = "";
                trims = new List<String>();
                filter();
                updateModels();
            }
        }

        public String model
        {
            get { return modelFilter; }
            set
            {
                modelFilter = value;
                yearFilter = "";
                trimFilter = "";
                trims = new List<String>();
                filter();
                updateYears();
                
            }
        }

        public String year
        {
            get { return yearFilter; }
            set
            {
                yearFilter = value;
                trimFilter = "";
                filter();
                updateTrims();
            }
        }

        public String trim
        {
            get { return trimFilter; }
            set
            {
                trimFilter = value;
                filter();
            }
        }

        private void filter()
        {
            filteredList.Clear();
            foreach (Vehicle vehicle in vehicleList)
            {
                if((vehicle.getMake().Equals(makeFilter) || makeFilter.Equals("")) 
                    && (vehicle.getModel().Equals(modelFilter) || modelFilter.Equals("")) 
                    && (vehicle.getYear().Equals(yearFilter) || yearFilter.Equals("")) 
                    && (vehicle.getTrim().Equals(trimFilter) || trimFilter.Equals("")))
                {
                    filteredList.Add(vehicle);
                }
            }
        }

        private void updateMakes()
        {
            makes = new List<String>();
            foreach (Vehicle vehicle in filteredList)
            {
                if (!makes.Contains(vehicle.getMake()))
                    makes.Add(vehicle.getMake());
            }
            if (makes.Count == 1)
                make = makes[0];
        }
        private void updateModels()
        {
            models = new List<String>();
            foreach (Vehicle vehicle in filteredList)
            {
                if (!models.Contains(vehicle.getModel()))
                    models.Add(vehicle.getModel());
            }
            if (models.Count == 1)
                model = models[0];
        }
        private void updateYears()
        {
            years = new List<String>();
            foreach (Vehicle vehicle in filteredList)
            {
                if (!years.Contains(vehicle.getYear()))
                    years.Add(vehicle.getYear());
            }
            if (years.Count == 1)
                year = years[0];
        }

        private void updateTrims()
        {
            trims = new List<String>();
            foreach (Vehicle vehicle in filteredList)
            {
                if (!trims.Contains(vehicle.getTrim()))
                    trims.Add(vehicle.getTrim());
            }
            if (trims.Count == 1)
                trim = trims[0];
        }

        public void setFilters(String make, String model, String year, String trim)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.trim = trim;
        }

        public void clear()
        {
            filteredList = new List<Vehicle>(vehicleList);
            makeFilter = "";
            modelFilter = "";
            yearFilter = "";
            trimFilter = "";
            makes = new List<String>();
            models = new List<String>();
            years = new List<String>();
            trims = new List<String>();
            updateMakes();
        }

        public bool filterEmpty()
        {
            String allEmpty = make + model + year + trim;
            if (allEmpty.Equals(""))
                return true;
            else
                return false;
        }

        public bool filterFull()
        {
            return !make.Equals("") && !model.Equals("") && !year.Equals("") && !trim.Equals("");
        }

    }
}
