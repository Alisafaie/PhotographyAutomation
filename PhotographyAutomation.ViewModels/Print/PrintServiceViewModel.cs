namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintServiceViewModel
    {
        public int Id { get; set; }

        private string _serviceName;
        public string ServiceName
        {
            get => _serviceName;
            set
            {
                if (value.Length >= 0 && value.Length <= 50)
                {
                    _serviceName = value;
                }
            }
        }


        private string _serviceCode;
        public string ServiceCode
        {
            get => _serviceCode;
            set
            {
                if (value.Length >= 0 && value.Length <= 50)
                {
                    _serviceCode = value;
                }
            }
        }



        private string _serviceDescription;
        public string ServiceDescription
        {
            get => _serviceDescription;
            set
            {
                if (value.Length >= 0 && value.Length <= 50)
                {
                    _serviceDescription = value;
                }
            }
        }
    }
}
