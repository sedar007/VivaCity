using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Business.Implementations {
	public class BatimentService : IBatimentService {
		private readonly IBatimentDataAccess _batimentDataAccess;
		private readonly ILogger<BatimentService> _logger;
		public BatimentService(ILogger<BatimentService> logger, IBatimentDataAccess batimentDataAccess) {
			_logger = logger;
			_batimentDataAccess = batimentDataAccess;
		}
		
		public async Task<BatimentDto?> GetBatimentById(int id) {
			try {
				return (await _batimentDataAccess.GetBatimentById(id))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		public async Task<BatimentDto?> GetBatimentByType(int type) {
			try {
				return (await _batimentDataAccess.GetBatimentByType(type))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		public async Task<BatimentDto?> GetBatimentByIdType(int id, int type) {
			try {
				return (await _batimentDataAccess.GetBatimentByIdType(id, type))?.ToDto();
			} catch (Exception e) {
				_logger.LogError(e, e.Message);
				throw;
			}
		}
		
		
	}
}