//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputManagerGenerate.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputManagerGenerate : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManagerGenerate()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManagerGenerate"",
    ""maps"": [
        {
            ""name"": ""Target"",
            ""id"": ""9ad1d683-eeb9-4d6f-a27f-5470e9217154"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""5cb735a9-1c57-415e-8ca3-c58d1ab4afc5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""373ef7de-e7c6-4ff2-b9d9-84870cc5dae3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""9bac64a3-2f5d-4a45-93eb-c76873c5289d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""627c5734-05c1-4769-bf1c-23414993a30e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15889ad4-9970-49d1-b1c5-b02d2e68176d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e8cfa84e-b06d-4ebf-930e-a137190d4cad"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""153d29cd-5b2c-40ce-862f-ce6b9f7a9631"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""66ca03c3-c54a-4ff4-8599-676c11cfe0d1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Target
        m_Target = asset.FindActionMap("Target", throwIfNotFound: true);
        m_Target_Moving = m_Target.FindAction("Moving", throwIfNotFound: true);
        m_Target_Interact = m_Target.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Target
    private readonly InputActionMap m_Target;
    private ITargetActions m_TargetActionsCallbackInterface;
    private readonly InputAction m_Target_Moving;
    private readonly InputAction m_Target_Interact;
    public struct TargetActions
    {
        private @InputManagerGenerate m_Wrapper;
        public TargetActions(@InputManagerGenerate wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_Target_Moving;
        public InputAction @Interact => m_Wrapper.m_Target_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Target; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TargetActions set) { return set.Get(); }
        public void SetCallbacks(ITargetActions instance)
        {
            if (m_Wrapper.m_TargetActionsCallbackInterface != null)
            {
                @Moving.started -= m_Wrapper.m_TargetActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_TargetActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_TargetActionsCallbackInterface.OnMoving;
                @Interact.started -= m_Wrapper.m_TargetActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TargetActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TargetActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_TargetActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public TargetActions @Target => new TargetActions(this);
    public interface ITargetActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
