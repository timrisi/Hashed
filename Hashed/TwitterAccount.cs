using System;
using MonoTouch.Foundation;
using MonoTouch.Accounts;

namespace Hashed
{
	public static class TwitterAccount
	{
		public static ACAccount twitterAccount;
		
		public static void getAccount()
		{
			if (twitterAccount != null)
				return;
			
			ACAccountStore accountStore = new ACAccountStore();
			ACAccountType accountTypeTwitter = accountStore.FindAccountType(ACAccountType.Twitter);
			accountStore.RequestAccess(accountTypeTwitter, (granted, error) => 
			{
				if (!granted)
					return;
				
				ACAccount[] accounts = accountStore.FindAccounts(accountTypeTwitter);
				if (accounts.Length > 0)
					twitterAccount = accounts[0];
			});
		}
	}
}

