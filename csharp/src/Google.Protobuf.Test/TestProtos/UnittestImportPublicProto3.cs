// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: unittest_import_public_proto3.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.TestProtos {

  /// <summary>Holder for reflection information generated from unittest_import_public_proto3.proto</summary>
  public static partial class UnittestImportPublicProto3Reflection {

    #region Descriptor
    /// <summary>File descriptor for unittest_import_public_proto3.proto</summary>
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UnittestImportPublicProto3Reflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiN1bml0dGVzdF9pbXBvcnRfcHVibGljX3Byb3RvMy5wcm90bxIYcHJvdG9i",
            "dWZfdW5pdHRlc3RfaW1wb3J0IiAKE1B1YmxpY0ltcG9ydE1lc3NhZ2USCQoB",
            "ZRgBIAEoBUIdqgIaR29vZ2xlLlByb3RvYnVmLlRlc3RQcm90b3NiBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.TestProtos.PublicImportMessage), global::Google.Protobuf.TestProtos.PublicImportMessage.Parser, new[]{ "E" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PublicImportMessage : pb::IMessage<PublicImportMessage> {
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    private static readonly pb::MessageParser<PublicImportMessage> _parser = new pb::MessageParser<PublicImportMessage>(() => new PublicImportMessage());
    [global::System.Diagnostics.CodeAnalysis.MaybeNullAttribute]
    [global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    public static pb::MessageParser<PublicImportMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.TestProtos.UnittestImportPublicProto3Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PublicImportMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PublicImportMessage([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] PublicImportMessage other) : this() {
      e_ = other.e_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [return: global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    public PublicImportMessage Clone() {
      return new PublicImportMessage(this);
    }

    /// <summary>Field number for the "e" field.</summary>
    public const int EFieldNumber = 1;
    [global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute]
    [global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    private int e_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int E {
      get { return e_; }
      set {
        e_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals([global::System.Diagnostics.CodeAnalysis.AllowNullAttribute] object other) {
      return Equals(other as PublicImportMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals([global::System.Diagnostics.CodeAnalysis.AllowNullAttribute] PublicImportMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (E != other.E) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (E != 0) hash ^= E.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [return: global::System.Diagnostics.CodeAnalysis.NotNullAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] pb::CodedOutputStream output) {
      if (E != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(E);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (E != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(E);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] PublicImportMessage other) {
      if (other == null) {
        return;
      }
      if (other.E != 0) {
        E = other.E;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            E = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
