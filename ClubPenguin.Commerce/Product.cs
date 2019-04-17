// Product
using ClubPenguin.Commerce;

public class Product
{
	public string shared_key
	{
		get;
		private set;
	}

	public string gp_store_sku
	{
		get;
		private set;
	}

	public string apple_store_sku
	{
		get;
		private set;
	}

	public string csg_id
	{
		get;
		private set;
	}

	public string csg_external_reference
	{
		get;
		private set;
	}

	public string sku_duration
	{
		get;
		private set;
	}

	public string sku_trial_duration
	{
		get;
		private set;
	}

	public bool sku_is_recurring
	{
		get;
		private set;
	}

	public string title
	{
		get;
		private set;
	}

	public string price
	{
		get;
		private set;
	}

	public string type
	{
		get;
		private set;
	}

	public string description
	{
		get;
		private set;
	}

	public string sku
	{
		get;
		private set;
	}

	public string currencyCode
	{
		get;
		private set;
	}

	public string currencySymbol
	{
		get;
		private set;
	}

	public bool purchasable
	{
		get;
		private set;
	}

	public Product(string key = null, string gp_product = null, string apple_product = null, string csg_product = null, string duration = null, string trial_duration = null, bool is_recurring = true)
	{
		shared_key = key;
		gp_store_sku = gp_product;
		apple_store_sku = apple_product;
		csg_id = csg_product;
		sku_duration = duration;
		sku_trial_duration = trial_duration;
		sku_is_recurring = is_recurring;
		purchasable = false;
	}

	public void SetCSGData(string new_csg_id, string csg_ext_ref = null)
	{
		csg_id = new_csg_id;
		if (csg_ext_ref != null)
		{
			csg_external_reference = csg_ext_ref;
		}
	}

	public bool IsPurchasable()
	{
		return purchasable;
	}

	public bool NeedsSkuInformation()
	{
		return string.IsNullOrEmpty(title);
	}

	public bool IsTrial()
	{
		return !string.IsNullOrEmpty(sku_trial_duration);
	}

	public bool IsRecurring()
	{
		return sku_is_recurring;
	}

	public void AddStoreInformation(SkuInfo storeInfo)
	{
		title = storeInfo.title;
		price = storeInfo.price;
		description = storeInfo.description;
		sku = storeInfo.sku;
		currencyCode = storeInfo.currencyCode;
		currencySymbol = storeInfo.currencySymbol;
		purchasable = storeInfo.purchasable;
	}

	public void ClearStoreInformation()
	{
		title = null;
		price = null;
		description = null;
		sku = null;
		currencyCode = null;
		currencySymbol = null;
		purchasable = false;
	}

	public string GetStoreSKU()
	{
		return csg_id;
	}

	public override string ToString()
	{
		return $"<SkuInfo> Key: {shared_key}, product: {GetStoreSKU()}, \n duration {sku_duration}, trial {sku_trial_duration}, title: {title}, \n price: {price}, description: {description}, productId: {sku}, isPurchasable: {purchasable.ToString()}";
	}
}
