using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Buildings;

namespace ClassLibrary.Repository
{
	public class BuildingRepository: IRepository<int, IBuilding>
	{
		private HashSet<IBuilding> table = new HashSet<IBuilding>();
		
		public void Create(IBuilding instance)
		{
			if (!IsExist(instance))
				return;
			table.Add(instance);
		}

		public IBuilding Read(int key)
		{
			return table.FirstOrDefault(i => i.GetId() == key);
		}

		public void Update(IBuilding instance)
		{
			if (!IsExist(instance))
				return;
			var renewable = Read(instance.GetId());
			renewable.SetApartmentsCount(instance.GetApartmentsCount());
			renewable.SetBuildingHeight(instance.GetBuildingHeight());
			renewable.SetEntrancesCount(instance.GetEntrancesCount());
			renewable.SetFloorCount(instance.GetFloorCount());
		}

		public void Delete(IBuilding instance)
		{
			if (!IsExist(instance))
				return;
			table.Remove(instance);
		}
		
		public void Delete(int key)
		{
			var instance = Read(key);
			if (!IsExist(instance))
				return;
			Delete(instance);
		}

		private bool IsExist(IBuilding instance)
		{
			return !(instance is null
					|| table.Contains(instance)
					|| table.Any(i => i.GetId() == instance.GetId()));
		}
	}
}