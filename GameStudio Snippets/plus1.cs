using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACTransit.UI
{
    public class plus1 : Plus1PooledObj
    {

        SpriteRenderer sprite;

        void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        public SpriteRenderer getSprite() { return sprite; }

    }
}