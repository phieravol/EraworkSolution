using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ServiceViewModel.Public
{
    public class ServicesSearchFilterRequest : PagingRequestBase
    {
        public string? searchTerm { get; set; }
        public List<int>? CategoryIds { get; set; }
        public List<int>? SubCatesIds { get; set; }
        public List<OptionsViewModel<string>>? PriceOptions { get; set; } = new List<OptionsViewModel<string>>
        {
            new OptionsViewModel<string> {OptionId=1, OptionValue="Less than 5$"},
            new OptionsViewModel<string> {OptionId=2, OptionValue="5-10$"},
            new OptionsViewModel<string> {OptionId=3, OptionValue="10-20$"},
            new OptionsViewModel<string> {OptionId=4, OptionValue="20-50$"},
            new OptionsViewModel<string> {OptionId=5, OptionValue="More than 50$"},
        };
        
        public List<OptionsViewModel<string>>? ProviderOptions { get; set; } = new List<OptionsViewModel<string>>
        {
            new OptionsViewModel<string> {OptionId=1, OptionValue="Beginer"},
            new OptionsViewModel<string> {OptionId=2, OptionValue="Intermediate"},
            new OptionsViewModel<string> {OptionId=3, OptionValue="Profestional"},
            new OptionsViewModel<string> {OptionId=4, OptionValue="Expert"},
            new OptionsViewModel<string> {OptionId=5, OptionValue="Enterprise"},
        };

        

	}
}
