using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterSelectorController : MonoBehaviour
{
    [SerializeField] private Image UIsplashArt;
    [SerializeField] private TextMeshProUGUI UItext;
    [SerializeField] private GameObject readyCheck;
    private int TotalKitNumber;
    private int PlayerIndex;
    private int currKitId = 0;
    private float axisY_movementInput;
    private bool readyInput = false;
    private bool startInput = false;

    private bool isReady = false;
    
    void Start() {
        // Debug.Log(this.GetInstanceID());
        loadKitForPlayer(currKitId);
        TotalKitNumber = CharacterLayoutManager.Instance.kits.Count;
    }

    // go up down on consolse
    public void OnChangeCharacter(InputAction.CallbackContext ctx) {
        // Debug.Log("Called on change character");
        // Debug.Log(this.GetInstanceID());
        axisY_movementInput = ctx.ReadValue<Vector2>().y;
    }

    public void OnReady(InputAction.CallbackContext ctx) {
        // Debug.Log("Called on ready");
        // switch(ctx.phase) {
        //     case InputActionPhase.Started:
        //         readyInput = true;
        //         break;
        //     default:
        //         readyInput = false;
        //         break;
        // }
        readyInput = ctx.ReadValueAsButton();
    }

    public void OnStartGame(InputAction.CallbackContext ctx) {
        startInput = ctx.ReadValueAsButton();
    }

    void Update()
    {
        // kit selection
        if (!isReady) {
            if (axisY_movementInput > 0) {
                currKitId = (++currKitId) % TotalKitNumber;
                loadKitForPlayer(currKitId);
            }
            else if (axisY_movementInput < 0) {
                currKitId = Mathf.Abs(--currKitId) % TotalKitNumber;
                loadKitForPlayer(currKitId);
            }
        }

        //ready
        if (readyInput == true) {
            isReady = !isReady;
            setReady(isReady);
        }

        if (startInput == true) {
            PlayerConfigurationManager.Instance.StartGame();
        }
    }

    public void SetPlayerIndex(int index) {
        PlayerIndex = index;
    }

    public void loadKitForPlayer(int kitID) {
        PlayerConfigurationManager.Instance.changeKitPlayer(PlayerIndex,kitID);
        IKitInfo kit = CharacterLayoutManager.Instance.kits[kitID];
        UIsplashArt.sprite = kit.splashArt;
        UItext.text = $"{kit.kitName}";
    }

    public void setReady(bool setState) {
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyCheck.SetActive(setState);
    }
}
