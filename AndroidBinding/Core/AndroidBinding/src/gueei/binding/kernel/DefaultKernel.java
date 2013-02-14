package gueei.binding.kernel;

import gueei.binding.AttributeBinder;
import gueei.binding.ISyntaxResolver;
import gueei.binding.bindingProviders.AbsSpinnerViewProvider;
import gueei.binding.bindingProviders.AdapterViewProvider;
import gueei.binding.bindingProviders.CompoundButtonProvider;
import gueei.binding.bindingProviders.ExpandableListViewProvider;
import gueei.binding.bindingProviders.GenericViewAttributeProvider;
import gueei.binding.bindingProviders.ImageViewProvider;
import gueei.binding.bindingProviders.ListViewProvider;
import gueei.binding.bindingProviders.ProgressBarProvider;
import gueei.binding.bindingProviders.RatingBarProvider;
import gueei.binding.bindingProviders.SeekBarProvider;
import gueei.binding.bindingProviders.TabHostProvider;
import gueei.binding.bindingProviders.TextViewProvider;
import gueei.binding.bindingProviders.ViewAnimatorProvider;
import gueei.binding.bindingProviders.ViewProvider;
import android.app.Application;

public class DefaultKernel extends KernelBase {

	@Override
	protected void registerProviders(AttributeBinder attrBinder) {
		attrBinder.registerProvider(new TabHostProvider());
		attrBinder.registerProvider(new SeekBarProvider());
		attrBinder.registerProvider(new RatingBarProvider());
		attrBinder.registerProvider(new ProgressBarProvider());
		attrBinder.registerProvider(new ViewAnimatorProvider());
		attrBinder.registerProvider(new CompoundButtonProvider());
		attrBinder.registerProvider(new ImageViewProvider());
		attrBinder.registerProvider(new ExpandableListViewProvider());
		attrBinder.registerProvider(new AbsSpinnerViewProvider());
		attrBinder.registerProvider(new ListViewProvider());
		attrBinder.registerProvider(new AdapterViewProvider());
		attrBinder.registerProvider(new TextViewProvider());
		attrBinder.registerProvider(new ViewProvider());
		attrBinder.registerProvider(new GenericViewAttributeProvider());
	}

	@Override
	protected AttributeBinder createAttributeBinder(Application application) {
		return AttributeBinder.getInstance();
	}

	@Override
	protected ISyntaxResolver createSyntaxResolver(Application application) {
		return new DefaultSyntaxResolver();
	}
}
