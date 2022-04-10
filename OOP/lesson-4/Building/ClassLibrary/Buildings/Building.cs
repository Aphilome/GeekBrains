namespace ClassLibrary.Buildings
{
	public class Building : IBuilding
	{
		private static int _lastUsedId;
		
		private int _id;
		private double _buildingHeight;
		private int _floorCount;
		private int _apartmentsCount;
		private int _entrancesCount;

		public Building()
		{
			IncrementLastUsedId();
			_id = _lastUsedId;
		}
		
		public void SetBuildingHeight(double buildingHeight) => _buildingHeight = buildingHeight;

		public void SetFloorCount(int floorCount) => _floorCount = floorCount;

		public void SetApartmentsCount(int apartmentsCount) => _apartmentsCount = apartmentsCount;

		public void SetEntrancesCount(int entrancesCount) => _entrancesCount = entrancesCount;

		public double GetBuildingHeight() => _buildingHeight;
		
		public int GetFloorCount() => _floorCount;
		
		public int GetApartmentsCount() => _apartmentsCount;
		
		public int GetEntrancesCount() => _entrancesCount;
		
		public int GetId() => _id;

		public double CalcFloorHeight() => _buildingHeight / _floorCount;
		
		public int CalcApartmentsInEntrance() => _apartmentsCount / _entrancesCount;
		
		public int CalcApartmentsInFloor() => CalcApartmentsInEntrance() / _floorCount;

		private static void IncrementLastUsedId() => _lastUsedId++;
	}
}