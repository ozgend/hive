package gueei.binding.menu;

import gueei.binding.MulticastListener;
import android.view.MenuItem;

public class OnMenuItemClickListenerMulticast extends MulticastListener<MenuItem, MenuItem.OnMenuItemClickListener> implements MenuItem.OnMenuItemClickListener {

	public boolean onMenuItemClick(MenuItem item) {
		for (MenuItem.OnMenuItemClickListener l : listeners) {
			l.onMenuItemClick(item);
		}
		return true;
	}

	@Override
	public void registerToHost(MenuItem host) {
		host.setOnMenuItemClickListener(this);
	}

}
