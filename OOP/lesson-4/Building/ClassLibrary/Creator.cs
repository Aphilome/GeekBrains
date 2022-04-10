using ClassLibrary.Buildings;
using ClassLibrary.Repository;

namespace ClassLibrary
{
	public static class Creator
	{
		private static IRepository<int, IBuilding> _repository = new BuildingRepository();
		
		public static T CreateBuild<T>(double buildingHeight, int floorCount, int apartmentsCount, int entrancesCount) 
			where T: IBuilding, new()
		{
			var instance = new T();
			instance.SetBuildingHeight(buildingHeight);
			instance.SetFloorCount(floorCount);
			instance.SetApartmentsCount(apartmentsCount);
			instance.SetEntrancesCount(entrancesCount);

			_repository.Create(instance);
			
			return instance;
		}

		public static void RemoveBuilding(int key)
		{
			_repository.Delete(key);
		}
	}
}