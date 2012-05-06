using Model.Routing;

namespace UI.ViewModels
{
    public class RouteViewModel : ViewModelBase
    {
        #region Properties and Indexers
        
        public bool IsSelected { get; set; }
        public Route Route { get; private set; }

        #endregion

        #region Constructors and Destructor

        public RouteViewModel(Route route) {
            Route = route;
        }

        public override string ToString() {
            return "Route of " + Route.Steps.Count + " steps";
        }  

        #endregion
    }
}