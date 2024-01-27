namespace PartPicker.Models
{
    public class Vehicle
    {
        private String make;
        private String model;
        private String year;
        private String trim;
        private String pictureURL;
        public Vehicle(String make, String model, String year, String trim, string pictureURL)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.trim = trim;
            this.pictureURL = pictureURL;
        }

        public String getMake() { return make; }   
        public String getModel() { return model; }
        public String getYear() { return year; }
        public String getTrim() { return trim; }

        public override string ToString() 
        {
            return $"{make} {model} {year} {trim}";
        }

        public string PictureURL
        {
            get { return pictureURL;  }
        }
    }
}
