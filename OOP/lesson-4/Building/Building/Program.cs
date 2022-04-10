using ClassLibrary;
using MyBuilding = ClassLibrary.Buildings.Building;

namespace Building
{
	class Program
	{
		static void Main(string[] args)
		{
			var building1 = Creator.CreateBuild<MyBuilding>(100, 8, 160, 4);
			var building2 = Creator.CreateBuild<MyBuilding>(100, 8, 160, 4);
			
			Creator.RemoveBuilding(building1.GetId());
		}
	}
}
