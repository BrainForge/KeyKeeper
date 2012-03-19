using System;

namespace KeyKeeper
{
	public interface IActionRegistrator
	{
		int registerAction(string stamp_end, 
		                   string operation_id, 
		                   string worker_id, 
		                   string worker_reg_type,
		                   string item_id,
		                   string item_reg_type);
		
		int updateAction(uint journalID);
	}
}

