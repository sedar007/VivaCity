using VivaCityWebApi.Common.DAO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VivaCityWebApi.DataAccess.Implementations {
	public class BatimentDataAccess : IBatimentDataAccess {
		private readonly GameContext _context;
		public BatimentDataAccess(GameContext context) {
			this._context = context;
		}
		
		public Task<BatimentDao?> GetBatimentById(int id) {
			return _context.Batiments.FirstOrDefaultAsync(x => x.Id == id);
		}
		
		public Task<BatimentDao?> GetBatimentByType(int type) {
			return _context.Batiments.FirstOrDefaultAsync(x => x.Type == type);
		}
		
		public Task<BatimentDao?> GetBatimentByIdType(int id, int type) {
			return _context.Batiments.FirstOrDefaultAsync(x => x.Id == id && x.Type == type);
		}
	}
}
