// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#include <sstream>

#include <google/protobuf/compiler/code_generator.h>
#include <google/protobuf/descriptor.h>
#include <google/protobuf/descriptor.pb.h>
#include <google/protobuf/io/printer.h>
#include <google/protobuf/io/zero_copy_stream.h>

#include <google/protobuf/compiler/csharp/csharp_source_generator_base.h>
#include <google/protobuf/compiler/csharp/csharp_helpers.h>
#include <google/protobuf/compiler/csharp/csharp_names.h>
#include <google/protobuf/compiler/csharp/csharp_options.h>

namespace google {
namespace protobuf {
namespace compiler {
namespace csharp {

SourceGeneratorBase::SourceGeneratorBase(const FileDescriptor* descriptor,
                                         const Options *options)
    : descriptor_(descriptor), options_(options) {
}

SourceGeneratorBase::~SourceGeneratorBase() {
}

void SourceGeneratorBase::WriteGeneratedCodeAttributes(io::Printer* printer) {
  printer->Print("[global::System.Diagnostics.DebuggerNonUserCodeAttribute]\n");
}

void SourceGeneratorBase::WriteNullabilityAttribute(io::Printer* printer, Nullability option) {
  printer->Print(nullability(option));
  printer->Print("\n");
}

const char* SourceGeneratorBase::nullability(Nullability nullability) {
  switch (nullability) {
    case Nullability::ALLOW_NULL:
      return "[global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]";
    case Nullability::DISALLOW_NULL:
      return "[global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute]";
    case Nullability::MAYBE_NULL:
      return "[global::System.Diagnostics.CodeAnalysis.MaybeNullAttribute]";
    case Nullability::NOT_NULL:
      return "[global::System.Diagnostics.CodeAnalysis.NotNullAttribute]";
    case Nullability::RETURN_NOT_NULL:
      return "[return: global::System.Diagnostics.CodeAnalysis.NotNullAttribute]";
    case Nullability::RETURN_MAYBE_NULL:
      return "[return: global::System.Diagnostics.CodeAnalysis.MaybeNullAttribute]";
  }
}

std::string SourceGeneratorBase::class_access_level() {
  return this->options()->internal_access ? "internal" : "public";
}

const Options* SourceGeneratorBase::options() {
  return this->options_;
}

}  // namespace csharp
}  // namespace compiler
}  // namespace protobuf
}  // namespace google
