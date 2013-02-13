package gueei.binding.plugin.abs.attributes;

import com.actionbarsherlock.app.ActionBar;
import gueei.binding.ViewAttribute;
import gueei.binding.plugin.abs.BindableActionBar;

public class DisplayShowHome extends ViewAttribute<BindableActionBar, Boolean> {

	public DisplayShowHome(BindableActionBar view) {
		super(Boolean.class, view, "displayShowHome");
	}

	@Override
	protected void doSetAttributeValue(Object newValue) {
		getHost().getActionBar().setDisplayShowHomeEnabled(newValue.equals(Boolean.TRUE));
	}

	@Override
	public Boolean get() {
		return (getHost().getActionBar().getDisplayOptions() & ActionBar.DISPLAY_SHOW_HOME) 
				== ActionBar.DISPLAY_SHOW_HOME;
	}
}
