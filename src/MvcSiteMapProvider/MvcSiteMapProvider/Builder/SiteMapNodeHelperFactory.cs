﻿using System;
using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider.Xml;

namespace MvcSiteMapProvider.Builder
{
    /// <summary>
    /// Abstract factory that creates instances of <see cref="T:MvcSiteMapProvider.Builder.ISiteMapNodeHelper"/>.
    /// </summary>
    public class SiteMapNodeHelperFactory
        : ISiteMapNodeHelperFactory
    {
        public SiteMapNodeHelperFactory(
            ISiteMapNodeCreatorFactory siteMapNodeCreatorFactory,
            IDynamicSiteMapNodeBuilderFactory dynamicSiteMapNodeBuilderFactory,
            IReservedAttributeNameProvider reservedAttributeNameProvider
            )
        {
            if (siteMapNodeCreatorFactory == null)
                throw new ArgumentNullException("siteMapNodeCreatorFactory");
            if (dynamicSiteMapNodeBuilderFactory == null)
                throw new ArgumentNullException("dynamicSiteMapNodeBuilderFactory");
            if (reservedAttributeNameProvider == null)
                throw new ArgumentNullException("reservedAttributeNameProvider");

            this.siteMapNodeCreatorFactory = siteMapNodeCreatorFactory;
            this.dynamicSiteMapNodeBuilderFactory = dynamicSiteMapNodeBuilderFactory;
            this.reservedAttributeNameProvider = reservedAttributeNameProvider;
        }
        protected readonly ISiteMapNodeCreatorFactory siteMapNodeCreatorFactory;
        protected readonly IDynamicSiteMapNodeBuilderFactory dynamicSiteMapNodeBuilderFactory;
        protected readonly IReservedAttributeNameProvider reservedAttributeNameProvider;

        #region ISiteMapNodeHelperFactory Members

        public ISiteMapNodeHelper Create(ISiteMap siteMap)
        {
            return new SiteMapNodeHelper(
                siteMap,
                this.siteMapNodeCreatorFactory,
                this.dynamicSiteMapNodeBuilderFactory,
                this.reservedAttributeNameProvider);
        }

        #endregion
    }
}
