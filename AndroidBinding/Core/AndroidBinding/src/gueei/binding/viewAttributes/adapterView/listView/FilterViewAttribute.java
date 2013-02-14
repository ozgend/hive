package gueei.binding.viewAttributes.adapterView.listView;

import gueei.binding.ViewAttribute;
import android.widget.Filter;
import android.widget.ListView;

public class FilterViewAttribute extends ViewAttribute<ListView, Filter> {
	public FilterViewAttribute(ListView view) {
		super(Filter.class, view, "filter");
	}

	private Filter	mValue;

	@Override
	protected void doSetAttributeValue(Object newValue) {
		if (newValue instanceof Filter) {
			mValue = (Filter) newValue;
		}
	}

	@Override
	public Filter get() {
		return mValue;
	}
}
