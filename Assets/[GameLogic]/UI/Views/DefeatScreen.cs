using _GameCore_;
using UnityEngine;
using UnityEngine.UI;

namespace _GameLogic_.UI.Views
{
    public class DefeatScreen : GameView, IEnabledListener
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private TMPro.TMP_Text killCounter;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isUiDefeatScreen = true;
            entity.AddEnabledListener(this);
            entity.AddEnabled(false);
        }

        private void Awake()
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnEnable()
        {
            if(Contexts.sharedInstance.game.gameDataEntity != null)
                killCounter.text = $"You killed {Contexts.sharedInstance.game.gameDataEntity.killCounter.value} enemies";
        }

        private void OnRestartButtonClicked()
        {
            Contexts.sharedInstance.game.CreateEntity().isRestartRequest = true;
        }
        
        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        public void OnEnabled(GameEntity entity, bool value)
        {
            gameObject.SetActive(value);
        }
    }
}