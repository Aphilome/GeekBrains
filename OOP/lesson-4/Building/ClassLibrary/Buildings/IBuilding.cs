namespace ClassLibrary.Buildings
{
	public interface IBuilding
	{
		void SetBuildingHeight(double buildingHeight);
		void SetFloorCount(int floorCount);
		void SetApartmentsCount(int apartmentsCount);
		void SetEntrancesCount(int entrancesCount);

		double GetBuildingHeight();
		int GetFloorCount();
		int GetApartmentsCount();
		int GetEntrancesCount();
		int GetId();
		
		double CalcFloorHeight();
		int CalcApartmentsInEntrance();
		int CalcApartmentsInFloor();
	}
}