package crc64101253f27f447132;


public class RecyclerListHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XamarinSample.Activities.RecyclerListHolder, XamarinSample", RecyclerListHolder.class, __md_methods);
	}


	public RecyclerListHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerListHolder.class)
			mono.android.TypeManager.Activate ("XamarinSample.Activities.RecyclerListHolder, XamarinSample", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
