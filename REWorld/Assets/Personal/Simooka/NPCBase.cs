using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NPC
{

    public class NPCBase : MonoBehaviour, INPC
    {
        //NPCData
        [SerializeField]
        private NPCData NData;

        //マスクスプライト
        [SerializeField]
        private GameObject _maskSprite;

        //感情世界
        [SerializeField]
        private GameObject _emotionalWorld;

        //グラフィック
        [SerializeField]
        private SpriteRenderer _NPC;

        //セリフ
        [SerializeField]
        private TextMeshProUGUI _words;

        //アニメーター
        public Animator animator;

        public virtual void Start()
        {
            EmotionalWorld.SetActive(false);
            MaskSprite.SetActive(false);
            INPCData.InitNPCFlag();
            animator = GetComponent<Animator>();
            ChangeWorld();
        }

        //インターフェースの定義
        public NPCData INPCData => NData;

        public GameObject MaskSprite => _maskSprite;

        public GameObject EmotionalWorld => _emotionalWorld;

        public Sprite EmotionalWorldSprite => NData.Data.EmotionalWorldSprite;

        public SpriteRenderer NPCSprite => _NPC;

        public TextMeshProUGUI Words => _words;


        public virtual void AppearanceWorld()
        {
            EmotionalWorld.SetActive(true);
            MaskSprite.SetActive(true);
        }

        public virtual void ChangeWorld()
        {
            //感情世界の画像を変更
            EmotionalWorld.GetComponent<SpriteRenderer>().sprite
                = EmotionalWorldSprite;

            Words.text = NData.Data.Word;

            if (EmotionalWorld.active) AppearanceWorld();
        }

        public virtual void DisappearanceWorld()
        {
            EmotionalWorld.SetActive(false);
            MaskSprite.SetActive(false);
        }
    }
}