namespace Client.Infrastructure.Enums
{
	public enum EditFormType : int
	{
		Edit = 0,
		Create = 1,
	}

	public enum PlanLevel : int
    {
		Plan = 1,
		ActivityPlan = 2,
		ProductPlan = 3,
		CheckoutPlan = 4,
    }

	public enum PlanType : int
	{
		SuggestedPlan = 1,
		CheckoutPlan = 2,
	}


	public enum StackSpacing : int
    {
		Button = 1,
    }
}
