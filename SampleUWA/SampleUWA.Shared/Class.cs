using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleUWA.ClassLibrary
{
    public partial class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollection<Detail> Details { get; set; }
    }
}