using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgrejaMVC.Models
{
    internal class ModelHinoporMes
    {

        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();

        BancoDados banco = new BancoDados();

        public Axis[] XAxes { get; set; } = new Axis[]
        {
        new Axis
        {
            Labels = new[] { "Jan111", "Fev111" },
            Name = "Meses"
        }
        };

        public Axis[] YAxes { get; set; } = new Axis[]
        {
        new Axis
        {
            Name = "Quantidade",
            MinLimit = 0
        }
        };






    }
}
