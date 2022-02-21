package crc647af336ab0ec09c64;


public class StudentListAdapter_StudentListAdapterViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XamarinSample.Adapters.StudentListAdapter+StudentListAdapterViewHolder, XamarinSample", StudentListAdapter_StudentListAdapterViewHolder.class, __md_methods);
	}


	public StudentListAdapter_StudentListAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == StudentListAdapter_StudentListAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("XamarinSample.Adapters.StudentListAdapter+StudentListAdapterViewHolder, XamarinSample", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
