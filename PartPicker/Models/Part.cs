using System.Security.Cryptography.X509Certificates;

namespace PartPicker.Models
{
    public class Part
    {
        public Part selectedPart;
        
        public String partName;
        private String isolatedURL;
        private String expandedURL;
        public String currentURL;
		public HashSet<Part> subParts;
		public bool expanded = false;
        public bool isolated = false;
        private Part parent;
        public bool purchasable;
        public double price;

        public Part(String partName, String isolatedURL, String expandedURL, HashSet<Part> subParts, Part parent, double price = -1)
        {

            this.partName = partName;
            this.isolatedURL = isolatedURL;
            this.expandedURL = expandedURL;
            this.subParts = subParts;
            this.parent = parent;

            //optional parameters

            if(price >= 0)
            {
                this.price = price;
                purchasable = true;
            }
            else
				purchasable = false;

			currentURL = isolatedURL;

            if (parent == null)
            {
                isolate();
            }
        }


        public bool expand
        {
            get { return expanded; }
            set 
            {
                expanded = value;
                if (expanded == true)
                {
                    isolated = false;
                    if (parent != null)
                        parent.collapseParentTree(this);
                    currentURL = expandedURL;
                    passCurrentToParent(this);
                }
                else
                    isolate();
            }
        }

        public void isolate()
        {
            expanded = false;
            isolated = true;
            currentURL = isolatedURL;
            if (parent != null)
                parent.collapseParentTree(this);
            collapseSubTrees();
            passCurrentToParent(this);
        }

        public void collapseParentTree(Part Child)
        {
            foreach (Part p in subParts)
            {
                if (p != Child)
                {
                    p.collapseTree();
                }
            }
            if (parent != null)
                parent.collapseParentTree(this);
        }

        public void collapseTree()
        {
            collapseSubTrees();
            this.expanded = false;
			this.isolated = false;
		}

        public void collapseSubTrees()
        {
            if(subParts != null)
                foreach (Part p in subParts)
                    p.collapseTree();
        }

        public void passCurrentToParent(Part selected)
        {
            if (parent != null)
                parent.passCurrentToParent(selected);
            else //current node is head
                selectedPart = selected;
        }
    }
}
